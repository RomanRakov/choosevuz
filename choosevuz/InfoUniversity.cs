using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace choosevuz
{
    internal class InfoUniversity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public InfoUniversity(string id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }
    }
}
