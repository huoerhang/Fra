namespace Fra.Modularity
{
    public interface IApplicationLifecycleModuleContributor
    {
        void OnPreApplicationInitialization(ApplicationInitializationContext context);
        void OnApplicationInitialization(ApplicationInitializationContext context);

        void OnPostApplicationInitialization(ApplicationInitializationContext context);

        void OnApplicationShutdown(ApplicationShutdownContext context);
    }
}
