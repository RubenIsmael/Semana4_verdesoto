using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Semana_3.Models
{
    public class PacienteModel
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }

        public int Edad { get; set; }
        public string Telefono { get; set; }
        public int HabitacionId { get; set; } 

        public virtual HabitacionModel Habitacion { get; set; }
        public virtual ICollection<TratamientoModel> Tratamientos { get; set; } 
    }
}