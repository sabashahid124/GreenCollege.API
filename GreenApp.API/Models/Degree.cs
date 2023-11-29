using System;
using System.Collections.Generic;

namespace GreenCollege.API.Models;

public partial class Degree
{
    public int DegreeId { get; set; }

    public string DegreeName { get; set; } = null!;

    public virtual ICollection<Major> Majors { get; } = new List<Major>();
}
