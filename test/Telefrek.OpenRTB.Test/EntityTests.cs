using System;
using Telefrek.Core.Json;
using Telefrek.OpenRTB.Entities;
using Telefrek.OpenRTB.Serialization;
using Xunit;

namespace Telefrek.OpenRTB.Test
{
    public class EntityTests
    {
        static EntityTests() => SerializationUtil.RegisterSerializers();

        [Fact]
        public void MetricSerializesCorrectly()
        {
            var json = "{\"type\":\"type\",\"value\":0.2,\"vendor\":\"test\"}";
            var metric = json.FromJson<Metric>();
            Assert.NotNull(metric);
            Assert.Equal("type", metric.MetricType);
            Assert.Equal(0.2d, metric.Value);
            Assert.Equal("test", metric.Vendor);

            var test = metric.ToJson();
            Assert.NotNull(test);
            Assert.Equal(json, test);
        }
    }
}
