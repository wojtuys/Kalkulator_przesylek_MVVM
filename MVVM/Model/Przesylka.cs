using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Model
{
    public abstract class Przesylka
    {
        public string Adresat { get; set; }
        public double WagaKg{ get; set; }

        public Przesylka(string adresat, double wagaKg)
        {
            Adresat = adresat;
            WagaKg = wagaKg;
        }

        public abstract double ObliczCene();
    }

    public class PaczkaKurierska : Przesylka
    {
        public bool CzyEkspres { get; set; }

        public PaczkaKurierska(string adresat, double wagaKg, bool czyEkspres) 
            : base(adresat, wagaKg)
        {
            CzyEkspres = czyEkspres;
        }

        public override double ObliczCene()
        {
            double cenaPodstawowa = 15.0 + (WagaKg * 2.50);
            if (CzyEkspres)
            {
                cenaPodstawowa = cenaPodstawowa + 20.0;
            }

            return cenaPodstawowa;
        }


    }
}
