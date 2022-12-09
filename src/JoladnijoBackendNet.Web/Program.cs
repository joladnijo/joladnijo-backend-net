﻿using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("MySql"), new MySqlServerVersion(new Version(8, 0)), mysqlOptions => mysqlOptions.UseNetTopologySuite()
        )
    );
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Program>());

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

using (var scope = app.Services.CreateScope())
{
   var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
   db.Database.Migrate();
}

app.Run();
