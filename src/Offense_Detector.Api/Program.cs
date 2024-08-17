using Microsoft.EntityFrameworkCore;
using Offense_Detector.Api.Data;
using Offense_Detector.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(x => {
    string connection =  builder.Configuration["ConnectionStrings:MySQLConnect"] ?? throw new ArgumentNullException("Connection string is null");

    x.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

builder.Services.AddControllers();
builder.Services.AddSwagger();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
