using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Wba.Boeken.Lib.Services;

namespace Wba.Boeken.Lib.Entities
{
    [Table("boeken")]
    public class Boek
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string Titel { get; set; }
        public string AuteurId { get; set; }
        public string UitgeverId { get; set; }
        public int Jaar { get; set; }
        [Computed]
        public string AuteursNaam
        {
            get
            {
                return AuteurService.FindAuteur(AuteurId).Naam;
            }
        }
        [Computed]
        public string UitgeversNaam
        {
            get
            {
                return UitgeverService.FindUitgever(UitgeverId).Naam;
            }
        }

        public Boek()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Boek(string titel, string auteurId, string uitgeverId, int jaar) : this()
        {
            Titel = titel;
            AuteurId = auteurId;
            UitgeverId = uitgeverId;
            Jaar = jaar;
        }
        public Boek(string id, string titel, string auteurId, string uitgeverId, int jaar)
        {
            Id = id;
            Titel = titel;
            AuteurId = auteurId;
            UitgeverId = uitgeverId;
            Jaar = jaar;
        }
        public override string ToString()
        {
            return $"{Titel}";
        }
    }
}
