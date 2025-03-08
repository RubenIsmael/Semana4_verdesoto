using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Semana_3.Models
{
    public class EnfermeroModel
    {
        [Key]
        public int IdEnfermero { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string Apellido { get; set; }

        public int EspecialidadId { get; set; }
        public string Telefono { get; set; } // Asegúrate de que esta propiedad esté presente

        public virtual EspecialidadModel Especialidad { get; set; }
        public virtual ICollection<TratamientoModel> Tratamientos { get; set; }
    }
}