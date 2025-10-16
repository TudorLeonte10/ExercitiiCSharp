using Ex8.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex8
{
    public static class SequenceFactory
    {
        private static readonly Dictionary<string, ISequenceGenerator> _generators;

        static SequenceFactory()
        {
            _generators = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ISequenceGenerator).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (ISequenceGenerator)Activator.CreateInstance(t)!)
                .ToDictionary(g => g.Name.ToLower());
        }

        public static ISequenceGenerator? GetGenerator(string name)
        {
            _generators.TryGetValue(name.ToLower(), out var generator);
            return generator;
        }

        public static IEnumerable<string> GetAvailable()
        {
            return _generators.Keys;
        }

    }
}
