using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ensciens.Models;

public class EnsciensContext : DbContext
{
    public EnsciensContext(DbContextOptions<EnsciensContext> options)
        : base(options)
    {
    }

    public DbSet<Ensciens.Models.Eleve> Eleve { get; set; }

    public DbSet<Ensciens.Models.Bureau> Bureau { get; set; }

    public DbSet<Ensciens.Models.Club> Club { get; set; }

    public DbSet<Ensciens.Models.Evenement> Evenement { get; set; }

    public DbSet<Ensciens.Models.Famille> Famille { get; set; }

    public DbSet<Ensciens.Models.Publication> Publication { get; set; }

    public DbSet<Ensciens.Models.LienBureauEleve> LienBureauEleve { get; set; }

    public DbSet<Ensciens.Models.LienClubEleve> LienClubEleve { get; set; }

    public DbSet<Ensciens.Models.Commentaire> Commentaire { get; set; }
    public DbSet<Ensciens.Models.Publicateur> Publicateur { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LienBureauEleve>().ToTable("Lien Bureaux Eleve");
        modelBuilder.Entity<LienClubEleve>().ToTable("Lien Club Eleve");
        modelBuilder.Entity<Commentaire>().ToTable("Commentaires");
        modelBuilder.Entity<Publicateur>().ToTable("Publicateur");
    }

}
