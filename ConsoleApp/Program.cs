using Autofac;
using NovaPoshta.Core;
using NovaPoshta.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = CompositionRoot.Init();
            var jsonLogic = container.Resolve<IJsonLogic>();

        }
    }
}
