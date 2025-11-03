using PostalCodeLookup.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Try to use Azure Table Storage, fallback to in-memory if not available
var connectionString = builder.Configuration.GetConnectionString("AzureTableStorage");
if (!string.IsNullOrEmpty(connectionString) && connectionString != "UseDevelopmentStorage=true")
{
    // Use actual Azure Table Storage
    builder.Services.AddSingleton<IPostalCodeService, PostalCodeService>();
}
else
{
    // Use in-memory storage for development/demo
    builder.Services.AddSingleton<IPostalCodeService, InMemoryPostalCodeService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// Initialize sample data
using (var scope = app.Services.CreateScope())
{
    var postalCodeService = scope.ServiceProvider.GetRequiredService<IPostalCodeService>();
    await postalCodeService.InitializeSampleDataAsync();
}

app.Run();
