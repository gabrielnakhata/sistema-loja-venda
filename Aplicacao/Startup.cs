using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Aplicacao.Servico.Interfaces;
using Aplicacao.Servico;
using Dominio.Interfaces;
using Dominio.Servicos;
using Dominio.Repositorio;
using Repositorio.Entidades;
using Repositorio.Contexto;

namespace sistema_loja_venda
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // Este método é chamado em tempo de execução. Use este método para adicionar serviços ao container.

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("MyStock")));


            services.AddHttpContextAccessor(); // MUDANÇA - SIMULAR EM "AMBIENTE DE DEPLOY"...

            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Injeção de Dependências - cuidado com o Singleton!

            services.AddSession();

            //Serviço Aplicação: 
            services.AddScoped<IServicoAplicacaoCategoria, ServicoAplicacaoCategoria>();
            services.AddScoped<IServicoAplicacaoCliente, ServicoAplicacaoCliente>();
            services.AddScoped<IServicoAplicacaoProduto, ServicoAplicacaoProduto>();
            services.AddScoped<IServicoAplicacaoVenda, ServicoAplicacaoVenda>();
            services.AddScoped<IServicoAplicacaoUsuario, ServicoAplicacaoUsuario>();
            //Domínio:
            services.AddScoped<IServicoCategoria, ServicoCategoria>();
            services.AddScoped<IServicoCliente, ServicoCliente>();
            services.AddScoped<IServicoProduto, ServicoProduto>();
            services.AddScoped<IServicoVenda, ServicoVenda>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();

            //Repositório:
            services.AddScoped<IRepositorioCategoria, RepositorioCategoria>();
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            services.AddScoped<IRepositorioProduto, RepositorioProduto>();
            services.AddScoped<IRepositorioVenda, RepositorioVenda>();
            services.AddScoped<IRepositorioVenda_Produtos, RepositorioVenda_Produtos>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);
        }

        // Este método é chamado em tempo de execução. Use este método para configurar o pipeline de solicitação HTTP.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // O valor HSTS padrão é 30 dias. Você pode querer mudar isso em cenários de produção, consulte https://aka.ms/aspnetcore-hsts.
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
