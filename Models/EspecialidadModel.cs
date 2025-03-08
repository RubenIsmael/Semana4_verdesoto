using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Semana_3.Models
{
    public class EspecialidadModel
    {
        [Key]
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "El nombre de la especialidad es obligatorio.")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public string Funciones { get; set; }

        public virtual ICollection<EnfermeroModel> Enfermeros { get; set; }
    }
}