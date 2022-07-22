using EmployeeLoginInfo.Email;
using EmployeeLoginInfo.Email.EmailTemplate;
using EmployeeLoginInfo.Functions;
using EmployeeLoginInfo.Models;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Utility.Email;
using Utility.Models;

[assembly: FunctionsStartup(typeof(Startup))]
namespace EmployeeLoginInfo.Functions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.Services.BuildServiceProvider().GetService<IConfiguration>();
            string connectionString = configuration.GetConnectionString("UserDb2021");
            builder.Services.AddDbContext<EmployeeDb2022Context>(options =>
            options.UseSqlServer(configuration.GetConnectionString("UserDb2021")));
            builder.Services.AddHttpClient();
            builder.Services.Configure<EmailTemplate>(configuration.GetSection("EmailTemplate"));
            builder.Services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            builder.Services.AddScoped<IEmailNotification, EmailNotification>();

            builder.Services.AddOptions<EmailTemplate>()
             .Configure<IConfiguration>((settings, configuration) =>
             {
                 configuration.GetSection("EmailTemplate").Bind(settings);
             });

            builder.Services.AddOptions<EmailSetting>()
             .Configure<IConfiguration>((settings, configuration) =>
             {
                 configuration.GetSection("EmailSetting").Bind(settings);
             });
        }
    }
}
