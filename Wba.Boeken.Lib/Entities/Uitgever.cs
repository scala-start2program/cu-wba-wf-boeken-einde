using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Wba.Boeken.Lib.Entities
{
    [Table("uitgevers")]
    public class Uitgever
    {
        [ExplicitKey]
        public string Id { get; set; }
        public string Naam { get; set; }
        public Uitgever()
        {
            Id = Guid.NewGuid().ToString();
        }
        public Uitgever(string naam)
        {
            Id = Guid.NewGuid().ToString();
            Naam = naam;
        }
        public Uitgever(string id, string naam)
        {
            Id = id;
            Naam = naam;
        }
        public override string ToString()
        {
            return $"{Naam}";
        }
    }
}
