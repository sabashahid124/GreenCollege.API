using System;
using System.Collections.Generic;

namespace GreenCollege.API.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string CourseName { get; set; } = null!;

    public int MajorId { get; set; }

    public virtual Major Major { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; } = new List<Section>();
}
