using App.Data;
using Business.Interfaces;
using Data.Context;
using Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.Logging;

namespace App
{
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));


            services.AddDbContext<MeuDbContext>(options => options.UseInMemoryDatabase(databaseName: "DesafioMvc"));
            services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase(databaseName: "DesafioMvc"));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped<MeuDbContext>();
            services.AddScoped<ICurriculoRepository,CurriculoRepository>();
            services.AddScoped<IExperienciaEmpresasRepository, ExperienciaEmpresasRepository>();
            services.AddScoped<IExperienciaRepository, ExperienciaRepository>();
            services.AddScoped<IFormacaoRepository, FormacaoRepository>();
            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            var context = app.ApplicationServices.GetService<MeuDbContext>();
            AdicionarDadosTeste(context);

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }

        private static void AdicionarDadosTeste(MeuDbContext context)
        {
            var testeUsuario1 = new Business.Models.Curriculo
            {
                Nome = "Luiz David da Cunha Oliveira",
                DataNascimento= DateTime.Parse("24/05/1993"),
                ExperienciaTotal=2
            };
            context.Curriculos.Add(testeUsuario1);

            context.SaveChanges();
        }
    }
}
