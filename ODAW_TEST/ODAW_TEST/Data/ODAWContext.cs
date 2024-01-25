using ODAW_TEST.Models;
using Microsoft.EntityFrameworkCore;

namespace ODAW_TEST.Data
{
    public class ODAWContext: DbContext
    {
        public DbSet<Profesor> Profesori { get; set; }
        public DbSet<Materie> Materii { get; set; }

        public DbSet<ProfesorMaterie> ProfesorMaterie { get; set; }
        public ODAWContext(DbContextOptions<ODAWContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProfesorMaterie>().HasKey(mr => new { mr.ProfesorId, mr.MaterieId });

            modelBuilder.Entity<ProfesorMaterie>()
                        .HasOne(mr => mr.prof)
                        .WithMany(m3 => m3.ProfesorMaterie)
                        .HasForeignKey(mr => mr.ProfesorId);

            modelBuilder.Entity<ProfesorMaterie>()
                        .HasOne(mr => mr.materie)
                        .WithMany(m4 => m4.ProfesorMaterie)
                        .HasForeignKey(mr => mr.MaterieId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
