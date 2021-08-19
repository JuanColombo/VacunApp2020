using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VacunApp.Models
{
    public class DetalleCalendario
    {
        public int Id { get; set; }
        public int CalendarioId { get; set; }
        public  Calendario Calendario { get; set; }
        public int VacunaId { get; set; }
        public virtual Vacuna Vacuna { get; set; }
    }
}
