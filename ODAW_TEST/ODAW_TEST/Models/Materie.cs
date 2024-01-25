using ODAW_TEST.Models.Base;

namespace ODAW_TEST.Models
{
    public class Materie: BaseEntity
    {
        public string Nume { get; set; }

        public string Descriere { get; set;}

        public ICollection<ProfesorMaterie> ProfesorMaterie { get; set; }
    }
}
