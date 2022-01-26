using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBIgraphic.Model
{
    public class Plavka
    {
        public int Id { get; set; }
        public string NomerPlavki { get; set; }
        public string NomerShtuki { get; set; }

        public List<ZamerHirina>? ZamerHirinas { get; set; }
        public List<ZamerTolchina>? ZamerTolchinas { get; set; }
        [NotMapped]
        public List<ZamerHirina> SelectShirina
        {
            get
            {
                return DataWorker.GetAllZamerHirinaByPlavkaId(Id);
            }
        }
    }
}
