using System;
using System.Collections.Generic;

namespace Issakov_Jacob_Final_Exam.Models;

public partial class Group
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<UserGroup> UserGroups { get; } = new List<UserGroup>();
}
