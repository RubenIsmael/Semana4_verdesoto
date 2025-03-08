using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Semana_3.Models
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