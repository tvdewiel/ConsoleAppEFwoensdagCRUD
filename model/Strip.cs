using System;
using System.Collections.Generic;
using System.Text;

namespace EFcrud.Model
{
    public class Strip
    {
        public Strip(int nr, string titel)
        {
            Nr = nr;
            Titel = titel;
        }
        public Strip(int nr, string titel, Uitgeverij uitgever, Reeks reeks) : this(nr, titel)
        {
            Uitgever = uitgever;
            Reeks = reeks;
        }
        public Strip()
        {
        }

        public int StripID { get; set; }
        public int Nr { get; set; }
        public string Titel { get; set; }
        public Uitgeverij Uitgever { get; set; }
        public Reeks Reeks { get; set; }
        public ICollection<Auteur> Auteurs { get; set; } = new List<Auteur>();
        public void VoegAuteurToe(Auteur auteur)
        {
            Auteurs.Add(auteur);
        }
        public override string ToString()
        {
            return $"Strip[ID:{StripID},Nr:{Nr},Titel:{Titel},Auteurs:{Auteurs.Count},\nUitgever:{Uitgever},\nReeks:{Reeks}]";
        }
        public void ToonDetail()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(this);
            Console.ResetColor();
            foreach (var al in Auteurs)
            {
                Console.WriteLine(al);
            }
        }
    }
}
