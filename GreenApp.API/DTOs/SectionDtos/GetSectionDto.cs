namespace GreenCollege.API.DTOs.SectionDtos
{
    public class GetSectionDto
    {
        public int SectionId { get; set; }

        public string SectionName { get; set; } = null!;

        public int CourseId { get; set; }

        public int AcademicYearId { get; set; }
    }
}
