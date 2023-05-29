using Microsoft.EntityFrameworkCore;
using PR_ERP_WebAPI.Domain.AssemblyReference;
using PR_ERP_WebAPI.Domain.Data;
using PR_ERP_WebAPI.Repository;
using PR_ERP_WebAPI.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PRERP_APIDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebAPI_ConnectionString")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AssemblyReference).Assembly);
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IOrderRepository, OrderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
