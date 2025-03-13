using System.ComponentModel.DataAnnotations;

namespace Semana4.Models
{
    public class TratamientoModel
    {
        [Key]
        public int IdTratamiento { get; set; }

        [Required(ErrorMessage = "El nombre del tratamiento es obligatorio.")]
        public string Tratamiento { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(300, ErrorMessage = "Máximo 300 caracteres")]
        public string Descripcion { get; set; }
        // Claves foráneas
        public int PacienteId { get; set; }
        public int EnfermeroId { get; set; }
        // Propiedades de navegación
        public virtual PacienteModel Paciente { get; set; }
        public virtual EnfermeroModel Enfermero { get; set; }
    }
}
