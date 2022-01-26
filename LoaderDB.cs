using SBIgraphic.Model;
using SBIgraphic.ReadFile;
using System;
using System.Globalization;
using System.Linq;

namespace SBIgraphic
{
    public class LoaderDB
    {
        public void CreateDb() 
        {
            using (ApplicattionContext db = new ApplicattionContext())
            {
                string path = @"F:\SBIgraphic\07Nov21.ti";
                var readInf = new ReadFileTi(path);
                var resultInfoFile = readInf.ReadFile();

                foreach (var item in resultInfoFile)
                {
                    var lineParse = item;
                    var arrayLineParse = lineParse.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                    Plavka plavka = new Plavka { NomerPlavki = arrayLineParse[2], NomerShtuki = arrayLineParse[3], };
                    db.Plavka.Add(plavka);
                    db.SaveChanges();
                    int initNamberTh = Convert.ToInt32(arrayLineParse[6]);
                    var zamerHirinaString = arrayLineParse.Skip(7).Take(initNamberTh).ToArray();

                    for (int i = 0; i < zamerHirinaString.Count(); i++)
                    {
                        double.TryParse(zamerHirinaString[i], System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double resultZhirina);
                        ZamerHirina zamerHirinas = new ZamerHirina { Shirina = resultZhirina, Plavka = plavka };
                        db.ZamerHirinas.Add(zamerHirinas);
                        db.SaveChanges();
                    }

                    int initNamberWith = 7 + initNamberTh;
                    int endPositionlin = arrayLineParse.Length - initNamberWith;
                    var zamerTolhina = arrayLineParse.Skip(initNamberWith).Take(endPositionlin).ToArray();

                    for (int i = 0; i < zamerTolhina.Count(); i++)
                    {

                        double.TryParse(zamerTolhina[i], System.Globalization.NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out double resultTolchina);
                        ZamerTolchina zamerTolchinas = new ZamerTolchina { Tolshina = resultTolchina, Plavka = plavka };
                        db.ZamerTolchinas.Add(zamerTolchinas);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}
