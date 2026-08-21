using NUnit.Framework;
using Newtonsoft.Json;
using TLabs.ExchangeSdk.CryptoAdapters;

namespace TLabs.ExchangeSdk.Tests;

[TestFixture]
public class ClientTypeTests
{
    [Test]
    public void AmlFee_HasStableNameAndValue()
    {
        Assert.AreEqual(90, (int)ClientType.AmlFee);
        Assert.AreEqual("AmlFee", ClientType.AmlFee.ToString());
        Assert.AreEqual(ClientType.AmlFee, System.Enum.Parse<ClientType>("AmlFee"));
    }

    [Test]
    public void AmlFee_AdapterContract_RoundTrips()
    {
        var adapterInfo = JsonConvert.DeserializeObject<AdapterInfo>(JsonConvert.SerializeObject(new AdapterInfo
        {
            AmlFeeAddress = "aml-fee-address",
        }));

        Assert.AreEqual("aml-fee-address", adapterInfo.AmlFeeAddress);
    }
}
