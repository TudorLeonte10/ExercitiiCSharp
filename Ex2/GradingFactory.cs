using Ex2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    public static class GradingFactory
    {
        private static readonly List<IGradingStrategy> _strategies;

        static GradingFactory()
        {
            _strategies = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IGradingStrategy).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (IGradingStrategy)Activator.CreateInstance(t)!)
                .ToList();
        }

        public static IEnumerable<IGradingStrategy> GetStrategies() => _strategies;

        public static IGradingStrategy? GetByName(string name)
            => _strategies.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
