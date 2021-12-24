using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Classes.Marketplace
{
    class PropertyRental
    {
        //Différents types de propriétés
        public enum TypeProperty
        {
            Apartment,
            House,
            RoomOnly
        }


        
        public int NbBedroom { get; init; }
        public int NbBathroom { get; init; }
        public int YearConstruction { get; init; }
        public int Prix { get; init; }
        public Uri ImgSrcApart { get; init; }
        public DateTime Date { get; init; }



    }
}
