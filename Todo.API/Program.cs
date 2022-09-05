using Audit.API.Protos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Todo.API.Data;
using Todo.API.Data.Repositories;
using Todo.API.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

// Add services to the container.
var configuration = builder.Configuration;
builder.Services.AddEntityFrameworkNpgsql()
             .AddDbContext<DataContext>(options => options.UseNpgsql(configuration.GetConnectionString("DbConnection")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<IAuditService, AuditService>();

builder.Services.AddGrpcClient<AuditProtoService.AuditProtoServiceClient>(opts => opts.Address = new Uri(configuration["GrpcSettings:AuditUrl"]));
;

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();
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
