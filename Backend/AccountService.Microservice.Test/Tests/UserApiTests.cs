using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;
using AccountService.Microservice.Test.Stubs;
using AccountService.Microservice.Data;
using Xunit;
using AccountService.Models;
using AccountService.Microservice.DTOs;

namespace AccountService.Microservice.Test
{
    public class UserApiTests : WebApplicationFactory<UserProgram>
    {
        UserDALStub stub = new();
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IUserDAL, UserDALStub>();
            });
            return base.CreateHost(builder);
        }

        [Fact]
        public async void GetUsers_Passed()
        {
            // Arrange
            var webAppFactory = new UserApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            //Act
            var response = await httpClient.GetAsync("/user/all");

            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async void AddCertainUser_Passed()
        {
            // Arrange
            UserCreateDTO userModel = new UserCreateDTO();
            userModel.Username = "mark";
            userModel.Password = "mark123";
            userModel.Email = "mark@gmail.com";
            userModel.Postalcode = "2352GL";
            var webAppFactory = new UserApiTests();
            HttpClient httpClient = webAppFactory.CreateClient();
            stub.testValue = true;

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(userModel);

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // Act
            var response = await httpClient.PostAsync("/user/add", httpContent);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
