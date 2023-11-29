using System;
using System.Collections.Generic;

namespace GreenCollege.API.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string SectionName { get; set; } = null!;

    public int CourseId { get; set; }

    public int AcademicYearId { get; set; }

    public virtual AcademicYear AcademicYear { get; set; } = null!;

    public virtual Course Course { get; set; } = null!;
}
