using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Paritee.StardewValley.Core.Utilities
{
    public class PropertyConstant
    {
        private string Name { get; set; }

        protected PropertyConstant(string name)
        {
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Name;
        }

        private static string Parse(string str)
        {
            return str.Replace(" ", "");
        }

        protected static bool Exists<T>(string str)
        {
            return str == null 
                ? false 
                : Utilities.Reflection.GetProperty(typeof(T), PropertyConstant.Parse(str), BindingFlags.Static | BindingFlags.Public) != null;
        }

        protected static List<T> All<T>()
        {
            return typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(p => (T)p.GetValue(typeof(T)))
                .ToList();
        }
    }
}
