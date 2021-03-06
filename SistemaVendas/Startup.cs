﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVendas.Servicos;
using SistemaVendas.Models;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.Models.Data;

namespace SistemaVendas {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            // usar seesion
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<SYSTEM_SALES_DBContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("SYSTEM_SALES_DBContext")));

            services.AddScoped<EstadoService>();
            services.AddScoped<TipoClienteService>();
            services.AddScoped<ClienteService>();
            services.AddScoped<VendedorService>();
            services.AddScoped<ProdutoService>();
            services.AddScoped<MedidaService>();
            services.AddScoped<VendaService>();
            services.AddScoped<SeendingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeendingService seendingService) {
            if (env.IsDevelopment()) {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                seendingService.Seed();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
