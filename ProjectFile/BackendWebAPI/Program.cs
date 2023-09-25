using Backend;
using Backend.Repository;
using BackendAPI.Profiles;
using CloudinaryDotNet;
using Core.Service;
using Data.Repository;
using Data.Service;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("CosmosDbConnection");
builder.Services.AddDbContext<ProgramContext>(options =>
{
    options.UseCosmos("https://localhost:8081", connectionString, "Program-Db");
});

builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<IProgramDetailsRepo, ProgramDetailsRepo>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IProgramDetailsService, ProgramDetailsService>();
builder.Services.AddScoped<IApplicationTemplateService, ApplicationTemplateService>();
builder.Services.AddScoped<IWorkFlowServices, WorkFlowServices>();
builder.Services.AddScoped<IApplicationPreviewService, ApplicationPreviewService>();
builder.Services.AddScoped<IPersonalInfoRepo, PersonalInfoRepo>();
builder.Services.AddScoped<Cloudinary>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
