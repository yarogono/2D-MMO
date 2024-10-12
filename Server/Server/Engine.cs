using Autofac;

namespace Server
{
    public static class Engine
    {
        private static IContainer _container;

        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        public static T Resolve<T>() where T : class
        {
            return Scope.Resolve<T>();
        }

        public static T Resolve<T>(Type type) where T : class
        {
            return (T)Scope.Resolve(type);
        }

        public static object Resolve(Type type)
        {
            return Scope.Resolve(type);
        }

        private static ILifetimeScope Scope
        {
            get
            {
                if (_container != null)
                    return _container.BeginLifetimeScope();

                throw new ArgumentNullException(nameof(_container));
            }
        }
    }
}
