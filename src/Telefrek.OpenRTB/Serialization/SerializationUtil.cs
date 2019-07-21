using Telefrek.Core.Json.Serialization;

namespace Telefrek.OpenRTB.Serialization
{
    /// <summary>
    /// Utility class for helping with seriaization updates
    /// </summary>
    public static class SerializationUtil
    {
        /// <summary>
        /// Register all serializers
        /// </summary>
        public static void RegisterSerializers()
        {
            JsonSerializationFactory.TryRegister(new MetricSerializer());
        }
    }
}