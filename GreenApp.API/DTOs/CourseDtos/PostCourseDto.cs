using GreenCollege.API.Models;
using System.Text.Json.Serialization;

namespace GreenCollege.API.DTOs.CourseDtos
{
    public class PostCourseDto
    {
        public string CourseName { get; set; } = null!;
        public int MajorId { get; set; }
        [JsonIgnore]
        public virtual ICollection<Section> Sections { get; } = new List<Section>();
    }
}
