using System;
using System.Collections.Generic;

namespace GreenCollege.API.Models;

public partial class Major
{
    public int MajorId { get; set; }

    public string MajorName { get; set; } = null!;

    public int DegreeId { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();

    public virtual Degree Degree { get; set; } = null!;
}
