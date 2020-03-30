using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PerfilCore.Teste
{
    [TestClass]
    public class FuncionalidadeTeste
    {
        private readonly HttpClient Client;

        public FuncionalidadeTeste()
        {
            string curDir = Directory.GetCurrentDirectory();

            var builder = new ConfigurationBuilder()
            .SetBasePath(curDir)
            .AddJsonFile("appsettings.json");

            var webBuilder = new WebHostBuilder()
                .UseContentRoot(curDir).UseConfiguration(builder.Build())
                .UseStartup<Startup>();
            
            var server = new TestServer(webBuilder);

            Client = server.CreateClient();
        }

        [TestMethod]
        public async System.Threading.Tasks.Task GetAllFuncionalideAsync()
        {
            var request = new HttpRequestMessage(new HttpMethod("Get"), "api/Funcionalidade/Listar");

            var response = await Client.SendAsync(request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public async System.Threading.Tasks.Task PostFuncionalideAsync()
        {
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "api/Funcionalidade/Adicionar");

            
            postRequest.Content = new StringContent("{\"descricao\":\"Add Funcionalidade\"}",
                                    Encoding.UTF8,
                                    "application/json");

           
            Client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await Client.SendAsync(postRequest);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

    }
}
