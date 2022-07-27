using HokoFood.Data;
using Microsoft.EntityFrameworkCore;

static void MigraDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<HokoFoodDbContext>();
        db.Database.Migrate();
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddDbContextPool<HokoFoodDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HokoFoodDb"));
});

builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();
//builder.Services.AddScoped<IRestaurantData, InMemoryRestaurantData>();

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
app.UseEndpoints(e =>
{
    e.MapRazorPages();
    e.MapControllers();
});

app.MapRazorPages();

MigraDatabase(app);

app.Run();
