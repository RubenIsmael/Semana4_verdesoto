using System.ComponentModel.DataAnnotations;

namespace Semana4.Models
{
    public class EspecialidadModel
    {
        [Key]
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "El nombre de la especialidad es obligatorio.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Mínimo 5 caracteres")]
        public string Especialidad { get; set; }

        public string Descripcion { get; set; }
        public string Funciones { get; set; }

        public virtual ICollection<EnfermeroModel> Enfermeros { get; set; }
    }
}
