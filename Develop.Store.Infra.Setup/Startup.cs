using Develop.Store.Domain.DTO;
using Develop.Store.Domain.Interfaces.Repositories;
using Develop.Store.Domain.Interfaces.Services;
using Develop.Store.Domain.Validations;
using Develop.Store.Infra.Data.Repositories;
using Develop.Store.Infra.Setup.Extensions;
using Develop.Store.Services.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Develop.Store.Infra.Setup
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureApp(IServiceCollection services)
        {
            ConfigureServices(services);
            ConfigureRepositories(services);
            ConfigureValidators(services);

            services
                .AddDevelopStoreContext(Configuration)
                .AddMongoClientConfiguration(Configuration);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISaleService, SaleService>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        private void ConfigureValidators(IServiceCollection services)
        {
            services.AddScoped<IValidator<ProductDTO>, ProductDTOValidator>();

        }
    }
}
