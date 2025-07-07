using FluentValidation;
using GoTap.MerchantService.Application.Features.Merchants.Commands.CreateMerchant;
using GoTap.MerchantService.Application.Interfaces;
using GoTap.MerchantService.Application.Validators;
using GoTap.MerchantService.Infrastructure.Services;
using GoTap.MerchantService.Persistence;
using GoTap.MerchantService.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MerchantDbContext>(opt =>
    opt.UseInMemoryDatabase("MerchantDb"));

builder.Services.AddMediatR(typeof(CreateMerchantCommand).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(CreateMerchantValidator).Assembly);
builder.Services.AddHttpClient<ICountryValidatorService, RestCountriesService>();
builder.Services.AddScoped<IMerchantRepository, MerchantRepository>();
builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();
app.MapControllers();
app.Run();
