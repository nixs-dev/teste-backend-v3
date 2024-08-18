using Microsoft.EntityFrameworkCore;

namespace TheatricalPlayersRefactoringKata.Models;

public class TheatreContext : DbContext
{
    public TheatreContext(DbContextOptions<TheatreContext> options) : base(options) {}

    public DbSet<Play> plays { get; set; }
    public DbSet<Performance> performances { get; set; }
    public DbSet<Invoice> invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Performance>()
            .HasOne(p => p.Invoice)
            .WithMany(i => i.Performances)
            .HasForeignKey(p => p.InvoiceId);
    }
}