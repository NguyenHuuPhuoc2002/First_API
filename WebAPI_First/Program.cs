
using DemoEntityFrameworkCore.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI_First.Models;
using WebAPI_First.Services;

namespace WebAPI_First
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //connect database
            builder.Services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MyDB")));

            

            //
            builder.Services.AddScoped<ILoaiRepository, LoaiRepository>();
            builder.Services.AddScoped<IHangHoaRepository, HangHoaRepository>();

            //token
            builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSettings"));

            var secretKey = builder.Configuration["AppSettings:SecretKey"]; //Lấy giá trị của SecretKey từ cấu hình

            //kiểm tra xem secretKey 
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("SecretKey is not configured.");
            }

            //chuyển đổi một chuỗi secretKey thành một mảng byte
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            //AddAuthentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //tự cấp token
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //ký vào token
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                    ValidateIssuerSigningKey = true,
                   
                    ClockSkew = TimeSpan.Zero,
                };
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
