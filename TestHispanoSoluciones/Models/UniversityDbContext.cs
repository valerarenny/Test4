namespace TestHispanoSoluciones.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UniversityDbContext : DbContext
    {
        public UniversityDbContext()
            : base("name=UniversityDbContext")
        {
        }

        public virtual DbSet<Asignacion> Asignacion { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Dias> Dias { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<Laboratorio> Laboratorio { get; set; }
        public virtual DbSet<PersonalAdministrativo> PersonalAdministrativo { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TipoLab> TipoLab { get; set; }
        public virtual DbSet<Turno> Turno { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>()
                .Property(e => e.Departamento1)
                .IsFixedLength();

            modelBuilder.Entity<Dias>()
                .Property(e => e.Dias1)
                .IsFixedLength();

            modelBuilder.Entity<Dias>()
                .HasMany(e => e.Turno)
                .WithOptional(e => e.Dias)
                .HasForeignKey(e => e.Dia_Desde);

            modelBuilder.Entity<Dias>()
                .HasMany(e => e.Turno1)
                .WithOptional(e => e.Dias1)
                .HasForeignKey(e => e.Dia_Hasta);

            modelBuilder.Entity<Docente>()
                .HasMany(e => e.Laboratorio)
                .WithOptional(e => e.Docente)
                .HasForeignKey(e => e.Id_Asignado);

            modelBuilder.Entity<PersonalAdministrativo>()
                .HasMany(e => e.Laboratorio)
                .WithOptional(e => e.PersonalAdministrativo)
                .HasForeignKey(e => e.Id_Encargado);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Rol1)
                .IsFixedLength();

            modelBuilder.Entity<Status>()
                .Property(e => e.Status1)
                .IsFixedLength();
        }
    }
}
