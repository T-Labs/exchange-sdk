using Newtonsoft.Json;
using NUnit.Framework;
using TLabs.ExchangeSdk.CryptoAdapters;

namespace TLabs.ExchangeSdk.Tests;

[TestFixture]
public class AdapterInfoTests
{
    [Test]
    public void AmlFeeAddress_RoundTrips()
    {
        var adapterInfo = JsonConvert.DeserializeObject<AdapterInfo>(JsonConvert.SerializeObject(new AdapterInfo
        {
            AmlFeeAddress = "aml-fee-address",
        }));

        Assert.AreEqual("aml-fee-address", adapterInfo.AmlFeeAddress);
    }
}
