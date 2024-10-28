using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto2.AccesoDatos.Data.Inicializador;
using Proyecto2.AccesoDatos.Data.Repository;
using Proyecto2.AccesoDatos.Data.Repository.IRepository;
using Proyecto2.Data;
using Proyecto2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConexionSQL") ?? throw new InvalidOperationException("Connection string 'ConexionSQL' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();


builder.Services.AddControllersWithViews();

//Agregar contenedor de trabajo al contenedor IoC de inyecci�n de dependencias

builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();

//Siembra de datos paso 1

builder.Services.AddScoped<IInicializadorBD, InicializadorDB>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

//Metodo que ejecuta la siembra de datos



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Cliente}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


//Funcionalidad de metodo de siembra de datos

void SiembraDatos()
{
    using (var scope = app.Services.CreateScope())
    {
        var inicializadorBD = scope.ServiceProvider.GetRequiredService<IInicializadorBD>();

        inicializadorBD.Inicializar();

    }
}