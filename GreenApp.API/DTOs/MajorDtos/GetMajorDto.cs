using GreenCollege.API.Models;
using System.Text.Json.Serialization;

namespace GreenCollege.API.DTOs.MajorDtos
{
    public class GetMajorDto
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; } = null!;
        public int DegreeId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Course> Courses { get; } = new List<Course>();
    }
}
