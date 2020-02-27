using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Telefrek.Core.Json;

namespace Telefrek.OpenRTB
{
    public static partial class OpenRTBExtensions
    {
        /// <summary>
        /// Extension method for adding a property if the value is not a default
        /// </summary>
        /// <param name="element">The element to modify</param>
        /// <param name="name">The property name</param>
        /// <param name="value">The property value</param>
        /// <typeparam name="T">The type of property value</typeparam>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddProperty<T>(this JsonObject element, string name, T value) where T : JsonElement
        {
            if (!value.IsNullOrDefault()) element.Add(name, value);
        }

        /// <summary>
        /// Validates if an object is the default for it's type
        /// </summary>
        /// <param name="instance">an instance of the object</param>
        /// <typeparam name="T">The type of object</typeparam>
        /// <returns></returns>
        public static bool IsNullOrDefault<T>(this T instance)
        {
            if (instance == null) return true;
            if (object.Equals(instance, default(T))) return true;

            var methodType = typeof(T);
            if (Nullable.GetUnderlyingType(methodType) != null) return false;

            var instanceType = instance.GetType();
            if (typeof(ICollection).IsAssignableFrom(instanceType))
            {
                var col = instance as ICollection;
                if (col == null || col.Count == 0)
                    return true;
            }

            if (instanceType.IsValueType && instanceType != methodType)
            {
                var obj = Activator.CreateInstance(instance.GetType());
                return obj.Equals(instance);
            }

            return false;
        }
    }
}