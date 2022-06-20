using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZADANIE_8_APBD.Models.DTOs
{
    public class PrescriptionGet
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public List<Medicament> Medicaments { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
