using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace sutnance.Models;

public enum MachineState
{
    Critique = 1,
    Stable =2 ,
    RetabliDocumente = 3,
    RetabliUndocumente = 4,
}

public abstract class AuditedTable
{
    public DateTime CreationTime { get; init; } = DateTime.UtcNow;  // gonna add more if needed 
}
[PrimaryKey(nameof(Id))]

public class Machine : AuditedTable
{
    
    public string Id { get; set; } // EQ-001
    public string Name { get; set; }
    public string Type { get; set; }
    public string Ip { get; set; }
    public string Site { get; set; }
    public DateTime BootTime { get; set; }

    [NotMapped]
    public Report? LastReport;
}
[PrimaryKey(nameof(Id))]

public class Report : AuditedTable
{
    
    public string Id { get; set; } // R-001
    public MachineState State { get; set; }
    public string MachineId { get; set; }
    public Machine Machine { get; set; }
}

[PrimaryKey(nameof(Id))]
public class Historique : AuditedTable
{
    public string Id { get; set; } // H-1024
    public string Title { get; set; }
    public string? TraitePar { get; set; }

    /*[ForeignKey(nameof(Machine))]*/
    public string MachineId { get; set; }
    /*[ForeignKey(nameof(Report))] WHAT THE !#@% */
    public string ReportId { get; set; }
    
    public Machine Machine { get; set; }
    public Report Report { get; set; }
    
}