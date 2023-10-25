using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class Auteur
    {
        public Auteur(string naam)
        {
            Naam = naam;
        }

        public int AuteurID { get; set; }
        public string Naam { get; set; }
        public ICollection<Strip> Strips { get; set; } = new List<Strip>();
        public override string ToString()
        {
            return $"Auteur[ID:{AuteurID},Naam:{Naam},strips:{Strips.Count}]";
        }
    }
}
