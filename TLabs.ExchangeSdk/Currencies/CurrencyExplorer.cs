using System.Collections.Generic;
using System.Linq;

namespace TLabs.ExchangeSdk.Currencies;

public class CurrencyExplorer
{
    public string CurrencyCode { get; set; }
    public string TransactionUrl { get; set; }
    public string AddressUrl { get; set; }

    public CurrencyExplorer()
    {

    }

    public CurrencyExplorer(string currencyCode, string transactionUrl, string addressUrl)
    {
        CurrencyCode = currencyCode;
        TransactionUrl = transactionUrl;
        AddressUrl = addressUrl;
    }

    // BTC and clones
    static readonly CurrencyExplorer BTC = new CurrencyExplorer("BTC", "https://www.blockchain.com/btc/tx/", "https://www.blockchain.com/btc/address/");
    static readonly CurrencyExplorer LTC = new CurrencyExplorer("LTC", "https://blockchair.com/litecoin/transaction/", "https://blockchair.com/litecoin/address/");
    static readonly CurrencyExplorer DASH = new CurrencyExplorer("DASH", "https://explorer.dash.org/insight/tx/", "https://explorer.dash.org/insight/address/");
    static readonly CurrencyExplorer DOGE = new CurrencyExplorer("DOGE", "https://dogechain.info/tx/", "https://dogechain.info/address/");
    static readonly CurrencyExplorer COLX = new CurrencyExplorer("COLX", "https://colx.tokenview.com/en/tx/", "https://colx.tokenview.com/en/address/");
    static readonly CurrencyExplorer SIN = new CurrencyExplorer("SIN", "https://explorer.sinovate.io/tx/", "https://explorer.sinovate.io/address/");
    static readonly CurrencyExplorer PZM = new CurrencyExplorer("PZM", "https://prizmexplorer.com/tx/", "https://prizmexplorer.com/address/");

    static readonly CurrencyExplorer ETH = new CurrencyExplorer("ETH", "https://etherscan.io/tx/", "https://etherscan.io/address/");
    static readonly CurrencyExplorer BNB = new CurrencyExplorer("BNB", "https://bscscan.com/tx/", "https://bscscan.com/address/");

    static readonly CurrencyExplorer TRX = new CurrencyExplorer("TRX", "https://tronscan.org/#/transaction/", "https://tronscan.org/#/address/");
    static readonly CurrencyExplorer ORGON = new CurrencyExplorer("ORGON", "https://orgonscan.org/transaction/", "https://orgonscan.org/address/");
    static readonly CurrencyExplorer DEL = new CurrencyExplorer("DEL", "https://explorer.decimalchain.com/transactions/", "https://explorer.decimalchain.com/address/");
    static readonly CurrencyExplorer UMI = new CurrencyExplorer("UMI", "https://blockchain.umi.top/transaction/", "https://blockchain.umi.top/address/");
    static readonly CurrencyExplorer TON = new CurrencyExplorer("TON", "https://tonscan.org/tx/", "https://tonscan.org/address/");

    public static readonly List<CurrencyExplorer> CurrencyExplorers = new List<CurrencyExplorer>()
            { BTC, LTC, DASH, DOGE, COLX, SIN, PZM, ETH, BNB, TRX, DEL, UMI, ORGON, TON };

    public static string GetTxUrl(string currencyCode, string txId)
    {
        CurrencyExplorer explorer = CurrencyExplorers.FirstOrDefault(c => c.CurrencyCode == currencyCode);
        string result = explorer != null ? $"{explorer.TransactionUrl}{txId}" : null;
        return result;
    }

    public static string GetAddressUrl(string currencyCode, string addressId)
    {
        CurrencyExplorer explorer = CurrencyExplorers.FirstOrDefault(c => c.CurrencyCode == currencyCode);
        string result = explorer != null ? $"{explorer.AddressUrl}{addressId}" : null;
        return result;
    }
}
