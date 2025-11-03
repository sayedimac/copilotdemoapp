using PostalCodeApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register AddressRepository based on configuration
var useAzureStorage = builder.Configuration.GetValue<bool>("UseAzureTableStorage");
if (useAzureStorage)
{
    builder.Services.AddSingleton<IAddressRepository, AddressRepository>();
}
else
{
    // Use in-memory repository for easier demo and testing
    builder.Services.AddSingleton<IAddressRepository, InMemoryAddressRepository>();
}

builder.Services.AddTransient<DataSeeder>();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    await seeder.SeedDataAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Address}/{action=Index}/{id?}");

app.Run();
