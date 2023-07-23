namespace TemplateCQRS.Presentation
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.OpenApi.Models;
    using Serilog;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using TemplateCQRS.Presentation.Extension;
    using TemplateCQRS.Presentation.Middleware;

    public class Startup
    {
     public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

     public IConfiguration Configuration { get; }

     public void ConfigureServices(IServiceCollection services)
        {
            var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

            services.AddControllers()
             .AddApplicationPart(presentationAssembly)
             .AddNewtonsoftJson()
             .AddJsonCamelCase();

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<AuthorizeCheck>();

                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme,
                    },
                };

                options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                var presentationDocumentationFile = $"{presentationAssembly.GetName().Name}";

                IncludeXmlComments(options, presentationDocumentationFile);
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Template CQRS", Version = "v1" });
            });

            services.AddCustomServices(this.Configuration);
        }

     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }

            // These 2 lines should be located in between UseRouting and UseEndpoints.
            // Otherwise, authentication or Authorization won't work
            app.UseAuthentication();
            app.UseAuthorization();

            // Configure Serilog middleware to capture HTTP request and response logs
            app.UseSerilogRequestLogging();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

     private static void IncludeXmlComments(SwaggerGenOptions options, string xmlFileName)
        {
            var xmlCommentsPath = Path.Combine(AppContext.BaseDirectory, $"{xmlFileName}.xml");

            if (File.Exists(xmlCommentsPath))
            {
                options.IncludeXmlComments(xmlCommentsPath, true);
            }
        }
    }
}

