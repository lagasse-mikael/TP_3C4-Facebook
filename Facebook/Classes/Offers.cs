using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Classes.Marketplace
{
    public class Offers
    {
        public string Titre { get; init; }
        public string Description { get; init; }
        public Uri ImgSrc { get; init; }
    }

  /*  public void loadOffers() 
    
    {
        List<Offers> offersToShow = new List<Offers>();
        if (RadioButtonDate.IsChecked == true)
            offersToShow = offerDictionnary.Values.OrderBy(post => post.Date).ToList();
        else
            OffersToShow = offerDictionnary.Values.OrderBy(post => post.Popularity).ToList();
    }
  */
}
