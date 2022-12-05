using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CDP.Data;
using CDP.Services;

namespace CourseWebApp;
public class Startup
    {
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddDbContext<CDPContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("CDPContext"),
                    ServerVersion.Parse("8.0.27-mysql")));

        
        services.AddScoped<UsuarioService>();
        services.AddScoped<CargoService>();
        services.AddScoped<FazendaService>();
        services.AddScoped<PlantioService>();
        services.AddScoped<TalhoesService>();
        services.AddScoped<FuncionarioService>();
        services.AddScoped<AvisoService>();
        services.AddScoped<SementeService>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env /*SeedingService seedingService*/)
    {
        var ptBR = new CultureInfo("pt-BR");

        var localizationOption = new RequestLocalizationOptions
        {
            DefaultRequestCulture = new RequestCulture("pt-BR"),
            SupportedCultures = new List<CultureInfo> { ptBR },
            SupportedUICultures = new List<CultureInfo> { ptBR }
        };

        app.UseRequestLocalization(localizationOption);

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            //seedingService.Seed();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
