using System.Data.Common;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Persistence;

public class DataContext : IdentityDbContext<Korisnik>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Novost> Novosti { get; set; } = null!;
    public DbSet<Sekcija> Sekcije { get; set; } = null!;
    public DbSet<Takmicenje> Takmicenja { get; set; } = null!;
    public DbSet<Ekipa> Ekipe { get; set; } = null!;
    public DbSet<ClanoviEkipe> ClanoviEkipe { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ClanoviEkipe>()
            .HasKey(ce => new { ce.Id, ce.EkipaId });
        
        modelBuilder.Entity<ClanoviEkipe>()
            .HasOne(ce => ce.Korisnik)
            .WithMany(k => k.ClanoviEkipe)
            .HasForeignKey(ce => ce.Id);

        modelBuilder.Entity<ClanoviEkipe>()
            .HasOne(ce => ce.Ekipa)
            .WithMany(e => e.Clanovi)
            .HasForeignKey(ce => ce.EkipaId);

        modelBuilder.Entity<Ekipa>()
            .HasOne(e => e.Takmicenje)
            .WithMany(t => t.PrijavljeneEkipe)
            .HasForeignKey(e => e.TakmicenjeId);
    }
}
