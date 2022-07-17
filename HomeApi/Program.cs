using Bill_api;
using HomeApi.Converters;
using Microsoft.AspNetCore.Mvc;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

TypeDescriptor.AddAttributes(typeof(LocalDate), new TypeConverterAttribute(typeof(LocalDateTypeConverter)));
// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.Configure<MvcNewtonsoftJsonOptions>(options =>
{
    options.SerializerSettings.ConfigureForNodaTime(DateTimeZoneProviders.Tzdb);
});

builder.Services.AddBillApi();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
