using EmployeeLoginInfo.Email;
using EmployeeLoginInfo.Email.EmailTemplate;
using EmployeeLoginInfo.Models;
using Microsoft.EntityFrameworkCore;
using Utility.Email;
using Utility.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeeDb2022Context>();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<EmployeeDb2022Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("UserDb2021")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeeDetails, EmployeeService>();
builder.Services.AddScoped<IAddEmployeeDetails, AddEmployeeService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IEmailNotification, EmailNotification>();
builder.Services.Configure<EmailTemplate>(builder.Configuration.GetSection("EmailTemplate"));
builder.Services.Configure<EmailSetting>(builder.Configuration.GetSection("EmailSetting"));


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("http://localhost:4200",
                            "https://localhost:4200")
                                 .AllowAnyHeader()
                                .AllowAnyMethod();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();
