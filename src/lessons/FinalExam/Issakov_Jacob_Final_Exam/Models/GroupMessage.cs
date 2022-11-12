using System;
using System.Collections.Generic;

namespace Issakov_Jacob_Final_Exam.Models;

public partial class GroupMessage
{
    public int Id { get; set; }

    public int GroupId { get; set; }

    public int UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public string Message { get; set; } = null!;
}
