using System.Collections.Generic;

namespace TLabs.ExchangeSdk.Aml
{
    /// <summary>Outcome of a single AML provider screening (MistTrack and similar).</summary>
    public class AmlScreeningResult
    {
        /// <summary>Provider risk score, normalized to 0..100 (higher = riskier).</summary>
        public int RiskScore { get; set; }

        public AmlRiskLevel RiskLevel { get; set; } = AmlRiskLevel.Unknown;

        /// <summary>Risk labels reported by the provider (e.g. mixer, sanctions, darknet).</summary>
        public List<string> Labels { get; set; } = new();

        /// <summary>Raw provider response kept for the admin audit trail.</summary>
        public string RawResponse { get; set; }

        /// <summary>True when the screening could not be performed (no key, network error, unsupported network).</summary>
        public bool IsInconclusive { get; set; }

        /// <summary>A deposit is risky when its score reaches the configured threshold.</summary>
        public bool IsRisky(int riskScoreThreshold) => !IsInconclusive && RiskScore >= riskScoreThreshold;

        public override string ToString() =>
            $"{nameof(AmlScreeningResult)}(score:{RiskScore}, level:{RiskLevel}, " +
            $"labels:[{string.Join(",", Labels)}]{(IsInconclusive ? ", inconclusive" : "")})";
    }
}
