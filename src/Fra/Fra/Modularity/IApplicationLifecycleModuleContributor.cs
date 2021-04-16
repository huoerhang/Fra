namespace Fra.Modularity
{
    public interface IApplicationLifecycleModuleContributor :
        IApplicationPreInitializationModuleContributor,
        IApplicationInitializationModuleContributor,
        IApplicationPostInitializationModuleContributor,
        IApplicationShutdownModuleContributor
    {


    }
}
