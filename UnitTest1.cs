using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
//using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using WebService.test;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;

namespace WebService.test
{
    public class LicenseHandlerControllerTest
    {
        private string[] args;

        [Fact]
        public void PostLicenseHandler_Returns_Licence_Details()
        {
            // Arrange
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.Environment.ContentRootPath = "D:\\AnilDev\\WebService";   // This is a path that should be overridden to suit the local environment
                      
            LicenseHandlerController lichandlerController = new LicenseHandlerController(app.Environment);
            LicenseHandler licData = new LicenseHandler();
            licData.LicenseNumber = "1234567878990";// Note default is >> "LicenseNumber”:"1234567878990" "ClientName": "4-secure"
            licData.ClientName = "4-secure";
            // Act

            JsonResult resPost = lichandlerController.Post(licData);

            // Assert
            var res = resPost.Value;
            Assert.Equal(StatusCodes.Status200OK, res);
        }
    }
}
