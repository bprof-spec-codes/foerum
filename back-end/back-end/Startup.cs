using Data;
using Logic;
using Logic.Class;
using Logic.Interface;
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
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

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
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(options =>
                {
                    this.Configuration.GetSection("AzureAd").Bind(options);
                    options.Events.OnRedirectToIdentityProvider = context =>
                    {
                        if (context.HttpContext.Items.ContainsKey("allowRedirect"))
                        {
                            return Task.CompletedTask;
                        }
                        context.HandleResponse();
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return Task.CompletedTask;
                    };
                });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });

            services.AddControllers();

            services.AddTransient<IAwardLogic>(x => new AwardLogic(Configuration["DBPassword"]));
            services.AddTransient<ICommentLogic>(x => new CommentLogic(Configuration["DBPassword"]));
            services.AddTransient<ICommentReactersLogic>(x => new CommentReactersLogic(Configuration["DBPassword"]));
            services.AddTransient<IMyUserLogic>(x => new MyUserLogic(Configuration["DBPassword"]));
            services.AddTransient<ISubjectLogic>(x => new SubjectLogic(Configuration["DBPassword"]));
            services.AddTransient<ISubjectUsersLogic>(x => new SubjectUsersLogic(Configuration["DBPassword"]));
            services.AddTransient<ITagLogic>(x => new TagLogic(Configuration["DBPassword"]));
            services.AddTransient<ITopicLogic>(x => new TopicLogic(Configuration["DBPassword"]));
            services.AddTransient<ITopicTagsLogic>(x => new TopicTagsLogic(Configuration["DBPassword"]));
            services.AddTransient<ITransactionLogic>(x => new TransactionLogic(Configuration["DBPassword"]));
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
            Console.WriteLine(Configuration["DBPassword"]);
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


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseStaticFiles();
            app.UseCors(policyBuilder => policyBuilder.AllowCredentials().SetIsOriginAllowed(origin => true).AllowAnyHeader())
                .UseHttpsRedirection()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
