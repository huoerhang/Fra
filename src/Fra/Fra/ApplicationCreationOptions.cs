using Microsoft.Extensions.DependencyInjection;

namespace Fra
{
    public class ApplicationCreationOptions
    {
        public ApplicationCreationOptions(IServiceCollection services)
        {
            Services = services;
            Configuration = new ConfigurationBuilderOptions();
        }

        public IServiceCollection Services { get; }

        public ConfigurationBuilderOptions Configuration { get; }
    }
}
