using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HalfSun_Proj.Model
{
    public class StaffModel
    {
        public StaffModel()
        {
            Benefits = new List<StaffBenefits>();
        }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; } = string.Empty;
        [JsonProperty("lastName")]
        public string LastName { get; set; } = string.Empty;
        [JsonProperty("address")]
        public string Address1 { get; set; } = string.Empty;
        [JsonProperty("staffTypeId")]
        public int? StaffTypeId { get; set; }
        [JsonProperty("staffTypeName")]
        public string StaffTypeName { get; set; } = string.Empty;
        [JsonProperty("benefits")]
        public List<StaffBenefits> Benefits { get; set; }
    }
}
