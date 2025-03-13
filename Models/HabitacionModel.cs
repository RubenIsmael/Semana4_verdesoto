using System.ComponentModel.DataAnnotations;

namespace Semana4.Models
{
    public class HabitacionModel
    {
        [Key]
        public int IdHabitacion { get; set; }

        [Required(ErrorMessage = "El número de habitación es obligatorio.")]
        public string Numero { get; set; }

        public string Tipo { get; set; }

        public virtual ICollection<PacienteModel> Pacientes { get; set; }
    }
}
