using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HalfSun_Proj.Model
{
    public class StaffBenefits
    {
        [JsonProperty("benefitId")]
        public int BenefitId {  get; set; }
        [JsonProperty("benefitName")]
        public string BenefitName { get; set; } = string.Empty;
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
