using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Facebook
{
    public enum CategorieEvent
    {
        Art,
        Games,
        Music,
        Social,
        Online,
        Live
    }
    public class Event
    {
        public string Titre { get; init; }
        public string Description { get; init; }
        public DateTime Date { get; init; }
        public string Duree { get; init; }
        public string Adresse { get; init; }
        public Uri Image { get; init; }
        public CategorieEvent Categorie { get; init; }

        public bool EstPublique { get; init; }
    }
}
