var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Configure the configuration to read from appsettings.json
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

var app = builder.Build();

// Access your API key from configuration
string apiKey = app.Configuration.GetSection("MovieDbApi:ApiKey").Value;
string apiUrl = app.Configuration.GetSection("MovieDbApi:ApiUrl").Value;
string apiImagesUrl = app.Configuration.GetSection("MovieDbApi:ApiImagesUrl").Value;

// Now you have your API key and can use it as needed

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
