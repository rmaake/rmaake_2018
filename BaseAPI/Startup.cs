using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using BaseAPI.Models;
using BaseAPI.Repository.External.Suppliers;
using BaseAPI.Repository.Internal.Clients;
using BaseAPI.Repository.Internal.Employees;
using BaseAPI.Repository.Internal.Projects.CostsEstimates;
using BaseAPI.Repository.Internal.Projects.Defaults;
using BaseAPI.Repository.Internal.Projects.Invoices;
using BaseAPI.Repository.Internal.Projects;
using BaseAPI.Repository.Tools;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BaseAPI
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
            services.AddScoped<IPasswordTools, PasswordTools>();
            services.AddScoped<IComMail, ComMail>();
            services.AddScoped<IAuthorizeRepo, AuthorizeRepo>();
            services.AddScoped<ITimelineRepo, TimelineRepo>();
            services.AddScoped<IProjectRepo, ProjectRepo>();
            services.AddScoped<Repository.Internal.Projects.Quotes.IQuoteRepo, Repository.Internal.Projects.Quotes.QuoteRepo>();
            services.AddScoped<Repository.Internal.Projects.Quotes.IQuoteItemRepo, Repository.Internal.Projects.Quotes.QuoteItemRepo>();
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();
            services.AddScoped<IInvoiceItemRepo, InvoiceItemRepo>();
            services.AddScoped<ICostEstimateRepo, CostEstimateRepo>();
            services.AddScoped<ICostEstimateItemRepo, CostEstimateItemRepo>();
            services.AddScoped<IDefaultRepo, DefaultRepo>();
            services.AddScoped<IDefaultTypeRepo, DefaultTypeRepo>();
            services.AddScoped<IClientContactInfoRepo, ClientContactRepo>();
            services.AddScoped<IClientRepo, ClientRepo>();
            services.AddScoped<ISupplierAccountRepo, SupplierAccountRepo>();
            services.AddScoped<ISupplierRepo, SupplierRepo>();
            services.AddScoped<Repository.External.Quotes.IQuoteItemRepo, Repository.External.Quotes.QuoteItemRepo>();
            services.AddScoped<Repository.External.Quotes.IQuoteRepo, Repository.External.Quotes.QuoteRepo>();
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            services.AddScoped<IEmployeeAccountRepo, EmployeeAccountRepo>();
            services.AddScoped<IEmployeeKinRepo, EmployeeKinRepo>();
            services.AddScoped<IProjectContentRepo, ProjectContentRepo>();
            services.AddScoped<IProjectFileRepo, ProjectFileRepo>();
            services.AddScoped<IClientFeedbackRepo, ClientFeedbackRepo>();
            services.AddScoped<IFeedbackCommentRepo, FeedbackCommentRepo>();
            services.AddScoped<IEmployeeRoleRepo, EmployeeRoleRepo>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<BaseApiContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("aws")));
            services.AddScoped<IMailService, MailService>();
            services.AddSingleton<IMailConfig>(Configuration.GetSection("EmailConfiguration").Get<MailConfig>());
            services.AddTransient<IMailService, MailService>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options => {
                options.Events.OnRedirectToLogin = (context) =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });
            services.AddCors(option => option.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin()
            .AllowAnyOrigin()   
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(builder => builder.AllowAnyOrigin()
            .AllowAnyOrigin()
            .AllowCredentials()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseHttpsRedirection();
            
            app.UseMvc();
        }
    }
}
