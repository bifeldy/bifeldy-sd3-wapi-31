/**
 * 
 * Author       :: Basilius Bias Astho Christyono
 * Mail         :: bias@indomaret.co.id
 * Phone        :: (+62) 889 236 6466
 * 
 * Department   :: IT SD 03
 * Mail         :: bias@indomaret.co.id
 * 
 * Catatan      :: Bifeldy's Entry Point
 * 
 */

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using bifeldy_sd3_lib_31;
using bifeldy_sd3_lib_31.Models;

using bifeldy_sd3_wapi_31.Handlers;
using bifeldy_sd3_wapi_31.Utilities;

namespace bifeldy_sd3_wapi_31 {

    public sealed class Startup {

        private IConfiguration _config { get; }

        // Example :: http://0.0.0.0:0/api
        private const string apiUrlPrefix = "api";

        public Startup(IConfiguration config) {
            _config = config;
        }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<Env>(_config.GetSection("ENV"));

            services.AddCors();
            services.AddControllers();

            Bifeldy.InitServices(services);
            Bifeldy.AddSwagger(apiUrlPrefix, "Portal Database API", "Tempat Lempar Query :: Oracle / Postgre / MsSQL");
            Bifeldy.AddDependencyInjection();

            services.AddSingleton<IApp, CApp>();
            services.AddSingleton<IDb, CDb>();
            services.AddSingleton<IBranchCabang, CBranchCabang>();
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(x =>
                x.SetIsOriginAllowed(origin => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );

            Bifeldy.InitApp(app);
            Bifeldy.UseSwagger(apiUrlPrefix);
            Bifeldy.UseApiKeyMiddleware();
            Bifeldy.UseJwtMiddleware();

            app.UseEndpoints(x => x.MapControllers());
        }

    }

}
