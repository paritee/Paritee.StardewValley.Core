using System;
using System.Reflection;

namespace Paritee.StardewValley.Core.Utilities
{
    public class Reflection
    {
        public static PropertyInfo GetProperty(object obj, string name, BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            return obj is Type type
                ? type.GetProperty(name, bindingAttr)
                : obj.GetType().GetProperty(name, bindingAttr);
        }

        public static FieldInfo GetField(object obj, string name, BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            return obj is Type type
                ? type.GetField(name, bindingAttr)
                : obj.GetType().GetField(name, bindingAttr);
        }

        public static T GetFieldValue<T>(object obj, string name, BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            FieldInfo fieldInfo = Utilities.Reflection.GetField(obj, name, bindingAttr);
            obj = obj is Type type ? null : obj;

            return (T)fieldInfo.GetValue(obj);
        }

        public static MethodInfo GetMethod(object obj, string name, BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            return obj is Type type
                ? type.GetMethod(name, bindingAttr)
                : obj.GetType().GetMethod(name, bindingAttr);
        }
    }
}
