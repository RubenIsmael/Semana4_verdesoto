using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Semana_3.Models
{
    public class TratamientoModel
    {
        [Key]
        public int IdTratamiento { get; set; }

        [Required(ErrorMessage = "El nombre del tratamiento es obligatorio.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public int PacienteId { get; set; } 
        public int EnfermeroId { get; set; } 

        public virtual PacienteModel Paciente { get; set; }
        public virtual EnfermeroModel Enfermero { get; set; }
    }
}