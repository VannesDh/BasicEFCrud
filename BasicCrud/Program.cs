using System.Text.Json.Serialization;
using BasicCrud.Data;
using BasicCrud.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
 .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });;

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=restaurant.db"));
builder.Services.AddScoped<RestaurantService>();
builder.Services.AddScoped<FoodService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
