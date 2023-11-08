using Fitness.Models;
using Microsoft.EntityFrameworkCore;

namespace Fitness.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        public DbSet<Uebung> Uebungen { get; set; }

        public DbSet<GeplanteUebung> GeplanteUebungen { get; set; }

        public DbSet<Trainingsplan> Trainingsplaene { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Uebung>().HasData(
                new Uebung { UebungId = new Guid("FC52460C-790D-4F11-B5E8-D79A1657961A"), Name = "ButterflyReverse", Ausfuehrung = "Muss so gemacht werden", Muskelgruppe = Muskelkategorie.Rücken },
                new Uebung { UebungId = new Guid("850E6CCB-F0EB-41F8-8725-0238521A6CF6"), Name = "Butterfly", Ausfuehrung = "Muss anders gemacht werden", Muskelgruppe = Muskelkategorie.Brust },
                new Uebung { UebungId = new Guid("B00F32DF-FB45-4BBC-BFCF-EA4C40F565F5"), Name = "BizepsCurl", Ausfuehrung = "Muss wieder anders gemacht werden", Muskelgruppe = Muskelkategorie.Bizeps }
                ) ;

            modelBuilder.Entity<GeplanteUebung>().HasData(
                new GeplanteUebung { GeplanteUebungId = new Guid("72F4B931-447C-48FA-9521-BDC0BB7471F7"), UebungId = new Guid("FC52460C-790D-4F11-B5E8-D79A1657961A"), AnzahlSaetze = 3, TrainingsplanId = new Guid("3CF8B422-E92D-487B-8D4E-97A3E0E711A7") },
                new GeplanteUebung { GeplanteUebungId = new Guid("E479563F-F3A9-439B-BAC9-B662B450FB18"), UebungId = new Guid("850E6CCB-F0EB-41F8-8725-0238521A6CF6"), AnzahlSaetze = 4, TrainingsplanId = new Guid("3CF8B422-E92D-487B-8D4E-97A3E0E711A7") },
                new GeplanteUebung { GeplanteUebungId = new Guid("6E26BFB3-1E32-489F-A701-731C6CC771B1"), UebungId = new Guid("B00F32DF-FB45-4BBC-BFCF-EA4C40F565F5"), AnzahlSaetze = 3, TrainingsplanId = new Guid("3CF8B422-E92D-487B-8D4E-97A3E0E711A7") }
                );

            modelBuilder.Entity<Trainingsplan>().HasData(
                new Trainingsplan { TrainingsplanId = new Guid("3CF8B422-E92D-487B-8D4E-97A3E0E711A7"),Name = "Testplan" }
                );
            
        }

    }
}
