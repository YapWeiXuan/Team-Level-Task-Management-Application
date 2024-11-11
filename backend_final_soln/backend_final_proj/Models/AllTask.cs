using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_final_proj.Models;

public class AllTask
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public long? Id { get; set; }

    public string? Manager { get; set; }

    public string? ManagerEmail { get; set; }

    public string? TaskUser { get; set; }

    public string? TaskTitle { get; set; }

    public string? TaskDescription { get; set; }

    public DateTime? TimeCreated { get; set; }

    public DateTime? DueDate { get; set; }
}
