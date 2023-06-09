using vacaciones;
using vacaciones.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<vacacionesContext>("Data Source=localhost,1433; Initial Catalog=vacacionesDB;user id=sa;password=r00t.R00t;Encrypt=False");
builder.Services.AddScoped <IEmpleadoService, EmpleadoService> ();
builder.Services.AddScoped <ICargoService, CargoService> ();
builder.Services.AddScoped<IVacacion1Service, Vacacion1Service> ();
builder.Services.AddScoped<ICodigoTService, CodigoTService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    //documentacion del Rest Api
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
