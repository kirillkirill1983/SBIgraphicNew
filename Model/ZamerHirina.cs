using System.ComponentModel.DataAnnotations.Schema;

namespace SBIgraphic.Model
{
    public class ZamerHirina
    {
        public int Id { get; set; }
        public double Shirina { get; set; }

        public int PlavkaId { get; set; }
        public virtual Plavka Plavka { get; set; }

    }
}