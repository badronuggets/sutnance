using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sutnance.Areas.Identity.Data;
using sutnance.Models;

namespace sutnance.Data;

public class sutnanceContext : IdentityDbContext<sutnanceUser>
{
    public DbSet<Machine> Machines { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<Historique> Historiques { get; set; }
    
    public sutnanceContext(DbContextOptions<sutnanceContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // =====================
        // Machine → Reports
        // =====================
        modelBuilder.Entity<Report>()
            .HasOne(r => r.Machine)
            .WithMany()
            .HasForeignKey(r => r.MachineId)
            .OnDelete(DeleteBehavior.NoAction);

        // =====================
        // Historique → Machine
        // =====================
        modelBuilder.Entity<Historique>()
            .HasOne(h => h.Machine)
            .WithMany()
            .HasForeignKey(h => h.MachineId)
            .OnDelete(DeleteBehavior.NoAction);

        // =====================
        // Historique → Report
        // =====================
        modelBuilder.Entity<Historique>()
            .HasOne(h => h.Report)
            .WithMany()
            .HasForeignKey(h => h.ReportId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
