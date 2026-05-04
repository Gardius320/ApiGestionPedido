using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderManagement.Data;
using OrderManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<PedidoRepository>();          //agregue los demás repositorios
builder.Services.AddScoped<ProductoRepository>();        
builder.Services.AddScoped<PedidoDetalleRepository>();   
builder.Services.AddControllers();
builder.Services.AddDbContext<OrderManagementDbContext>(options =>
//options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); //con el buildes nos vamos  con Get al archivo .json y obtenemos la cadena de conexion con el nombre DefaultConnection
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionNewDB")));

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
