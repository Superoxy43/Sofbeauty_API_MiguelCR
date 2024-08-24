using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Sofbeauty_API_MiguelCR.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        //agregamos codigo que permite la inteccion de la cadena de conexion contenida en appsettings.json.

        //1. obtener el valor de la cadena de conexion en appsettings
        var CnnStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CnnStr"));

        //2. como en la cadena de conexion eliminamos el password, lo vamos a incluir directamente en este codigo fuente.
        CnnStrBuilder.Password = "123Queso";

        //3. creamos un string con la info de la cadena de conexion
        string cnnStr = CnnStrBuilder.ConnectionString;

        //4. vamos a asignar el valor de esta cadena de conexion al DB Context que esta en Models
        builder.Services.AddDbContext<SofbeautyContext>(options => options.UseSqlServer(cnnStr));

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

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}