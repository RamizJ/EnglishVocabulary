using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Vocabilary.Views.Converters;
using Vocabulary.DataAccess;

namespace Vocabulary.Backend
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString(ConfigKeys.DB_CONNECTION_STRING);
            services.AddDbContext<DataContext>(options => 
                options.UseSqlServer(connectionString, o => o.MigrationsAssembly("Vocabulary.DataAccess")));

            if (Configuration.GetValue<bool>(ConfigKeys.IS_API_TEST_MODE))
            {
                services.AddCors(options => options
                    .AddDefaultPolicy(builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()));
            }

            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()))
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("v1", new OpenApiInfo { Title = "Vocabulary API", Version = "v1" });
                setup.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "Vocabulary.Backend.xml");
                setup.IncludeXmlComments(filePath);
            });
            services.AddSwaggerGenNewtonsoftSupport();

            //ViewModelConverters
            services.AddTransient<VmWordExampleConverter>();
            services.AddTransient<VmWordConverter>();
            services.AddTransient<VmWordSetConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
                app.UseSpaStaticFiles();

            app.UseRouting();

            if (Configuration.GetValue<bool>(ConfigKeys.IS_API_TEST_MODE))
                app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("./v1/swagger.json", "Vocabulary API V1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa => { });
        }
    }
}
