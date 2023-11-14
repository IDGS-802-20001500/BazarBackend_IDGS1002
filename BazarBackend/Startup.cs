using BazarBackend.Context;
using Microsoft.EntityFrameworkCore;

namespace BazarBackend
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("conexion"), sqlServerOptionsAction: sqlOptions => 
                {

                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null); ;
                
                });
            });

            services.AddCors(options =>
            {

                var frontedURL = Configuration.GetValue<string>("Fronted_url");
                options.AddPolicy("AllowReactDevServer", builder =>
                {

                    builder.WithOrigins("http://localhost:5173").AllowAnyMethod().AllowAnyHeader();

                });

            });

            services.AddControllers();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } 
            else
            {
                app.UseExceptionHandler("/Productos/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowReactDevServer");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Productos}/{action=Index}/{id?}");
            });


        }
    }
    
}
