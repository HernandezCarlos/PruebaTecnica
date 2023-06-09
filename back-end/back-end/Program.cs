using back_end.Data;
using back_end.Logic;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UsersLogic>();
builder.Services.AddScoped<ActivitiesLogic>();

builder.Services.AddDbContext<DbPruebaContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options => 
{ 
    options.AddPolicy("CORS", app =>
{
    app.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);

app.UseCors("CORS");

app.UseAuthorization();

app.MapControllers();


app.Run();




