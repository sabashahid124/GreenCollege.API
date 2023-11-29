namespace GreenCollege.API.DTOs.SectionDtos
{
    public class PostSectionDto
    {

        public string SectionName { get; set; } = null!;

        public int CourseId { get; set; }

        public int AcademicYearId { get; set; }
    }
}
