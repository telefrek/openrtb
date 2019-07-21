using Telefrek.Core.Json;
using Telefrek.Core.Json.Serialization;

namespace Telefrek.OpenRTB.Serialization
{
    /// <summary>
    /// Base serializer that takes care of some common logic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseSerializer<T> : IJsonSerializable<T> where T : class, new()
    {
        /// <inheritdoc/>
        public T Deserialize(JsonElement element)
        {
            // Check null
            if (element == null) return default(T);

            // Verify objecct
            if (element.IsJsonObject())
            {
                // Create the instance
                var instance = new T();

                // Process the properties
                foreach (var prop in element.AsJsonObject().Properties)
                {
                    // Skip empty properties
                    if (prop.Value == null || prop.Value.IsJsonNull()) continue;

                    Read(ref instance, prop);
                }

                return instance;
            }

            // Yup, not great
            throw new JsonSerializationException($"Cannot serialize non-object as {typeof(T).Name}");
        }

        /// <summary>
        /// Read the property into the instance
        /// </summary>
        /// <param name="instance">The current instance</param>
        /// <param name="prop">The property</param>
        protected abstract void Read(ref T instance, JsonProperty prop);

        /// <inheritdoc/>
        public abstract JsonElement Serialize(T instance);
    }
}