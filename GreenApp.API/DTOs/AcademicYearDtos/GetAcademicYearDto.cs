using GreenCollege.API.Models;
using System.Text.Json.Serialization;

namespace GreenCollege.API.DTOs.AcademicYearDtos
{
    public class GetAcademicYearDto
    {
        public int AcademicYearId { get; set; }

        public string AcademicYearName { get; set; } = null!;

        public string AcademicYearDuration { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Section> Sections { get; } = new List<Section>();
    }
}
