using DesignPatterns.Models.Data;
using DesignPatterns.Repository;
using DesignPatternsAsp.Configuration;
using Microsoft.EntityFrameworkCore;
using Tools.Earn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//                          //Hacemos una inyeccion de MyConfig para ser obtenido
//                          //  en cualquier controlador.
builder.Services.Configure<MyConfig>(builder.Configuration.GetSection("MyConfig"));

builder.Services.AddDbContext<DesignPatternContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

//                          //Inyeccion de LocalEarnFactory
builder.Services.AddTransient((factory) =>
{
    return new LocalEarnFactory(builder.Configuration
        .GetSection("MyConfig").GetValue<decimal>("LocalPercentage"));
});

//                          //Inyeccion de ForeingEarnFactory
builder.Services.AddTransient((factory) =>
{
    return new ForeingEarnFactory(builder.Configuration
        .GetSection("MyConfig").GetValue<decimal>("ForeingPercentage"),
        builder.Configuration
        .GetSection("MyConfig").GetValue<decimal>("Extra")
        );
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//                          //Hay que recordar que todo lo inyectado en la
//                          //  siguiente linea, va a hacer uso de todo
//                          //  de todo lo inyectado aca arriba.
//                          //Por ejemplo el Contexto inyectado arriba, 
//                          //  se va a inyectar magicamente en el constructor
//                          //  de la clase UnitOfWork.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
