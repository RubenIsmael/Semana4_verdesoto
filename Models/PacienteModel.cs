using System.ComponentModel.DataAnnotations;

namespace Semana4.Models
{
    public class PacienteModel
    {
        [Key]
        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre_paciente { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido_Paciente { get; set; }

        [Range(1, 120, ErrorMessage = "Edad debe ser entre 1 y 120")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Teléfono es obligatorio")]
        [RegularExpression(@"^\d{8,15}$", ErrorMessage = "Formato inválido (8-15 dígitos)")]
        public string Telefono { get; set; }
        public int HabitacionId { get; set; }

        // Propiedades de navegación
        public virtual HabitacionModel Habitacion { get; set; }
        public virtual ICollection<TratamientoModel> Tratamientos { get; set; }
    }
}
