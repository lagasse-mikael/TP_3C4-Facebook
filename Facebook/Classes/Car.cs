using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class Car
    {
        //Marque des fabriquants
        public enum FabCar
        {
            Toyota,
            Honda,
            Nissan
        }

        //Liste des différentes marques de véhicules
        public enum MarqueCar
        {
            Corolla,
            Yaris,
            Camry,

            Civic,
            Accord,

            Leaf,
            Infiniti,
            Altima


        }

        //public MarqueCar Marque { get; init; }
        //public FabCar Fabriquant { get; init; }
        public string Fabriquant { get; init; }
        public string Marque { get; init; }
        public int Annee { get; init; }
        public string Odometre { get; init; }
        public int Prix { get; init; }
        public Uri ImgSrcCar { get; init; }
        public DateTime Date { get; init; }



    }
}
