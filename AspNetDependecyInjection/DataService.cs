namespace AspNetDependecyInjection
{
    public class DataService
    {
        private readonly SingletonServices singletonServices;
        private readonly ScopedServices scopedServices;
        private readonly TransientServices transientServices;
        private readonly IServiceScopeFactory serviceScopeFactory;


        public DataService(TransientServices transientServices,
            ScopedServices scopedServices,
            SingletonServices singletonServices,
            IServiceScopeFactory serviceScopeFactory)
        {
            this.transientServices = transientServices;
            this.scopedServices = scopedServices;
            this.singletonServices = singletonServices;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        public void DoSomething()
        {
            using var scope = serviceScopeFactory.CreateScope();

            _ = scope.ServiceProvider.GetRequiredService<SingletonServices>();

            _ = scope.ServiceProvider.GetRequiredService<ScopedServices>();
        }
    }
}
