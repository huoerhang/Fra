using Microsoft.Extensions.DependencyInjection;

namespace Fra
{
    public class FraApplicationCreationOptions
    {
        public FraApplicationCreationOptions(IServiceCollection services)
        {
            Services = services;
            Configuration = new FraConfigurationBuilderOptions();
        }

        public IServiceCollection Services { get; }

        public FraConfigurationBuilderOptions Configuration { get; }
    }
}
