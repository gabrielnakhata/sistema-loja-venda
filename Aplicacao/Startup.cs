using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using sistema_loja_venda.DAL;
using Aplicacao.Servico.Interfaces;
using Aplicacao.Servico;
using Dominio.Interfaces;
using Dominio.Servicos;
using Dominio.Repositorio;
using Repositorio.Entidades;

namespace sistema_loja_venda
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // Este m�todo � chamado em tempo de execu��o. Use este m�todo para adicionar servi�os ao container.

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            

            //Fica por enquanto, pois o projeto ainda n�o foi migrado
            //completamente para o padr�o DDD...

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyStock")));
            // A boa pr�tica � que a ConnectionString v� p/ o arquivo appsettings.json!


            // A PRINCIPIO ser� o definitivo...
            services.AddDbContext<Repositorio.Contexto.ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyStock")));


            services.AddHttpContextAccessor(); // MUDAN�A - SIMULAR EM "AMBIENTE DE DEPLOY"...

            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Inje��o de Depend�ncias - cuidado com o Singleton!

            services.AddSession();

            //Servi�o Aplica��o: 
            services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();

            //Dom�nio:
            services.AddScoped<IServicoCategoria, ServicoCategoria>();

            //Reposit�rio:
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();


            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
        }

        // Este m�todo � chamado em tempo de execu��o. Use este m�todo para configurar o pipeline de solicita��o HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // O valor HSTS padr�o � 30 dias. Voc� pode querer mudar isso em cen�rios de produ��o, consulte https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
         // app.UseCookiePolicy();
            app.UseSession();   

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
