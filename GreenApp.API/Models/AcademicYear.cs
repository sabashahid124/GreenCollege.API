using System;
using System.Collections.Generic;

namespace GreenCollege.API.Models;

public partial class AcademicYear
{
    public int AcademicYearId { get; set; }

    public string AcademicYearName { get; set; } = null!;

    public string AcademicYearDuration { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; } = new List<Section>();
}
