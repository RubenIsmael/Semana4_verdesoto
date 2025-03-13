using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Semana4.Models;

namespace Semana4.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<EnfermeroModel> Enfermeros { get; set; }
    public DbSet<EspecialidadModel> Especialidades { get; set; }
    public DbSet<PacienteModel> Pacientes { get; set; }
    public DbSet<HabitacionModel> Habitaciones { get; set; }
    public DbSet<TratamientoModel> Tratamientos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<EnfermeroModel>()
           .HasOne(e => e.Especialidad)
           .WithMany(e => e.Enfermeros)
           .HasForeignKey(e => e.EspecialidadId);

        modelBuilder.Entity<PacienteModel>()
            .HasOne(p => p.Habitacion)
            .WithMany(h => h.Pacientes)
            .HasForeignKey(p => p.HabitacionId);

        modelBuilder.Entity<TratamientoModel>()
            .HasOne(t => t.Paciente)
            .WithMany(p => p.Tratamientos)
            .HasForeignKey(t => t.PacienteId);

        modelBuilder.Entity<TratamientoModel>()
            .HasOne(t => t.Enfermero)
            .WithMany(e => e.Tratamientos)
            .HasForeignKey(t => t.EnfermeroId);
    }
}

