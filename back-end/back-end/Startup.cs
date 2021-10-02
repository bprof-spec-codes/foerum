using Data;
using Logic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end
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
                  services.AddControllers();

                  services.AddTransient<IYearLogic>(x => new YearLogic(Configuration["DBPassword"]));

                  services.AddSwaggerGen(c =>
                  {
                        c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                  });

                  services.AddCors(options =>
                  {
                        options.AddDefaultPolicy(
                                          builder =>
                                          {
                                                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                          });
                  });

                  var connectionString = "server=95.111.254.24;database=foerumtst;user=foerumtst;password=" + Configuration["DBPassword"];
            services.AddDbContext<FoerumDbContext>(options => options.UseMySQL(connectionString));
                  services.AddIdentity<IdentityUser, IdentityRole>(
                           option =>
                           {
                                 option.Password.RequireDigit = false;
                                 option.Password.RequiredLength = 6;
                                 option.Password.RequireNonAlphanumeric = false;
                                 option.Password.RequireUppercase = false;
                                 option.Password.RequireLowercase = false;
                           }
                       ).AddEntityFrameworkStores<FoerumDbContext>()
                       .AddDefaultTokenProviders();
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                  if (env.IsDevelopment())
                  {
                        app.UseDeveloperExceptionPage();
                  }
                  else
                  {
                        app.UseExceptionHandler("/Error");
                        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                        app.UseHsts();
                  }

                  app.UseHttpsRedirection();
                  app.UseStaticFiles();

                  app.UseRouting();

                  app.UseSwagger();
                  app.UseSwaggerUI(c =>
                  {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                  });

                  app.UseAuthorization();
                  app.UseCors();

                  app.UseEndpoints(endpoints =>
                  {
                        endpoints.MapControllers();
                  });

            }
      }
}
