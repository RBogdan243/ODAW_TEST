using ODAW_TEST.Models.Base;

namespace ODAW_TEST.Models
{
    public class Profesor: BaseEntity
    {
        public string Tip_Profesor { get; set; }

        public string Nume {  get; set; }

        public string Prenume { get; set; }

        public double Salariu { get; set; }

        public ICollection<ProfesorMaterie> ProfesorMaterie { get; set; }
    }
}
