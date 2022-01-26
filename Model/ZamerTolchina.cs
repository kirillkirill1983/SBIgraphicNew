namespace SBIgraphic.Model
{
    public class ZamerTolchina
    {
        public int Id { get; set; }
        public double Tolshina { get; set; }

        public int PlavkaId { get; set; }
        public virtual Plavka Plavka { get; set; }

    }
}