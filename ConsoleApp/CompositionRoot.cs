using Autofac;
using NovaPoshta.Json;

namespace ConsoleApp
{
    public static class CompositionRoot
    {
        public static IContainer Init()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonLogic>();
            builder.Register(c => new JsonLogicLogger(c.Resolve<JsonLogic>())).As<IJsonLogic>();
            return builder.Build();
        }
    }
}
