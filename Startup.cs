using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PokéCoin.Context;

namespace PokéCoin
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            configuration = configuration;
        }
        // Este método é usado para configurar os serviços da aplicação.
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public IConfiguration Configuration { get; }    

        // Este método é usado para configurar o pipeline de requisições HTTP.
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
          
        }
    }
}