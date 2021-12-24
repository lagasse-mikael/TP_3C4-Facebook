using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Classes.Marketplace
{
    class Appliance
    {

        //Marque des fabriquants
        public enum TypeElectro
        {
            Stove,
            Fridge,
            Washer
        }

        //Liste des différentes marques de véhicules
        public enum MarqueElectro
        {
            Maytag,
            Samsung,
            LG,



        }

        public MarqueElectro Marque { get; init; }
        public TypeElectro TypeElec { get; init; }
        public int Annee { get; init; }
        public int Prix { get; init; }
        public Uri ImgSrcElectro { get; init; }
        public DateTime Date { get; init; }



    }
}
