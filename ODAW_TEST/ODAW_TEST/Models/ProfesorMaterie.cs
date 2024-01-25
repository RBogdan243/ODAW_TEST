namespace ODAW_TEST.Models
{
    public class ProfesorMaterie
    {
        public Guid ProfesorId { get; set; }
        public Profesor prof { get; set; }

        public Guid MaterieId { get; set; }
        public Materie materie { get; set; }
    }
}
