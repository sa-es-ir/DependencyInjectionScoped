namespace AspNetDependecyInjection
{
    public class SingletonServices
    {
        public SingletonServices()
        {
            Console.WriteLine($"Singletion: {Guid.NewGuid()}");
        }
    }

    public class ScopedServices
    {
        public ScopedServices()
        {
            Console.WriteLine($"Scoped: {Guid.NewGuid()}");
        }
    }

    public class TransientServices
    {
        public TransientServices()
        {
            Console.WriteLine($"Transient: {Guid.NewGuid()}");
        }
    }
}
