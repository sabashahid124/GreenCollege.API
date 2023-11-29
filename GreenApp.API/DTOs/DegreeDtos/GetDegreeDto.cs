using GreenCollege.API.Models;
using System.Text.Json.Serialization;

namespace GreenCollege.API.DTOs.DegreeDtos
{
    public class GetDegreeDto
    {
        public int DegreeId { get; set; }
        public string DegreeName { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Major> Majors { get; } = new List<Major>();
    }
}
