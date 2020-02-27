using Telefrek.Core.Json;
using Telefrek.OpenRTB.Entities;

namespace Telefrek.OpenRTB.Serialization
{
    /// <summary>
    /// Serializer for the <seealso cref="Telefrek.OpenRTB.Entities.Metric"/> class
    /// </summary>
    public class MetricSerializer : BaseSerializer<Metric>
    {
        /// <inheritdoc/>
        public override JsonElement Serialize(Metric instance)
        {
            // No sense in including this
            if (instance == null) return JsonNull.Instance;

            var element = new JsonObject();

            element.AddProperty("type", (JsonElement)instance.MetricType);
            element.AddProperty("value", (JsonElement)instance.Value);
            element.AddProperty("vendor", (JsonElement)instance.Vendor);

            return element;
        }

        /// <inheritdoc/>
        protected override void Read(ref Metric instance, JsonProperty prop)
        {
            switch (prop.Name)
            {
                case "type":
                    instance.MetricType = prop.Value.AsString();
                    break;
                case "value":
                    instance.Value = prop.Value.AsDouble();
                    break;
                case "vendor":
                    instance.Vendor = prop.Value.AsString();
                    break;
                default:
                    // Ignore, potentially warn in the future
                    break;
            }
        }
    }
}