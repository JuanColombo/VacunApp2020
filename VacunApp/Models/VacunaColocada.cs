
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VacunApp.Models
{
    public class VacunaColocada
    {
        public int Id { get; set; }
        public int VacunaId { get; set; }
        public  Vacuna Vacuna { get; set; }
        public int PacienteId { get; set; }
        public  Paciente Paciente { get; set; }
        public DateTime Fecha { get; set; }
    }
}
