using SBIgraphic.ReadFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace SBIgraphic.Model
{
    public static class DataWorker
    {
        public static List<Plavka> GetAllPlavka()
        {
            using (ApplicattionContext db = new ApplicattionContext())
            {

                var result = db.Plavka.ToList();

                return result;
            }
        }

        public static List<ZamerHirina> GetAllHirina()
        {
            using (ApplicattionContext db = new ApplicattionContext())
            {
                var result = db.ZamerHirinas.ToList();
                return result;
            }
        }

        public static List<ZamerTolchina> GetAllTolshina()
        {
            using (ApplicattionContext db = new ApplicattionContext())
            {
                var result = db.ZamerTolchinas.ToList();
                return result;
            }
        }



        public static List<ZamerHirina> GetAllZamerHirinaByPlavkaId(int id)
        {
            using (ApplicattionContext db = new ApplicattionContext())
            {
                List<ZamerHirina> zamerList = (from position in GetAllHirina() where position.PlavkaId == id select position).ToList();
                return zamerList;
            }
        }

        public static List<ZamerTolchina> GetAllZamerTolshinaByPlavkaId(int id)
        {
            using (ApplicattionContext db = new ApplicattionContext())
            {
                List<ZamerTolchina> zamerList = (from position in GetAllTolshina() where position.PlavkaId == id select position).ToList();
                return zamerList;
            }
        }
    }
}
