using Flurl.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabs.DotnetHelpers;

namespace TLabs.ExchangeSdk.CryptoAdapters.NownodesApi
{
    /// <summary>
    /// NowNodes - multi-blockchain api
    /// https://documenter.getpostman.com/view/13630829/TVmFkLwy#intro
    /// </summary>
    public class ClientCryptoNownodes
    {
        private readonly ILogger _logger;

        public ClientCryptoNownodes(
            ILogger<ClientCryptoNownodes> logger)
        {
            _logger = logger;
        }

        public string ToNownodesCoin(string currencyCode)
        {
            currencyCode = currencyCode.ToLower();
            if (currencyCode == "bnb")
                currencyCode = "bsc";
            return currencyCode;
        }

        public string GetBlockbookUrl(string currencyCode)
        {
            string coin = ToNownodesCoin(currencyCode);
            if (coin == "eth" || coin == "bsc")
                return $"https://{coin}-blockbook.nownodes.io";
            else
                return $"https://{coin}book.nownodes.io";
        }

        /// <summary>
        /// Common api for different chains.
        /// Doesn't suppport TRX
        /// </summary>
        public async Task<NownodesNodeStatus> GetNodeStatus(string apiKey, string currencyCode)
        {
            string url = $"{GetBlockbookUrl(currencyCode)}/api";
            var result = await url.ExternalApi().WithHeader("api-key", apiKey)
                .GetJsonAsync<NownodesNodeStatus>();
            return result;
        }

        public async Task<long> GetLastBlockNumTrx(string apiKey)
        {
            var result = await "https://trx.nownodes.io/wallet/getnowblock".ExternalApi().WithHeader("api-key", apiKey)
                .GetJsonAsync<dynamic>();
            return result["block_header"]["raw_data"]["number"];
        }

        public async Task<long> GetLastBlockNum(string apiKey, string currencyCode)
        {
            if (currencyCode == "TRX")
            {
                return await GetLastBlockNumTrx(apiKey);
            }
            else
            {
                var status = await GetNodeStatus(apiKey, currencyCode);
                return status.Backend.Blocks;
            }
        }
    }
}
