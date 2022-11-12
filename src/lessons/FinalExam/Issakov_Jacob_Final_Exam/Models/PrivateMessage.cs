﻿using System;
using System.Collections.Generic;

namespace Issakov_Jacob_Final_Exam.Models;

public partial class PrivateMessage
{
    public int Id { get; set; }

    public int FromUserId { get; set; }

    public int ToUserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public bool IsUserInBlackList { get; set; }

    public string? AdditionalInfo { get; set; }
}
