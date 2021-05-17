using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMay
{
    class Role : IComparable
    {
        public Role(string name)
        {
            Name = name;
        }
        public Role()
        {            
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(object obj)
        {
            return Name.CompareTo((obj as Role).Name);
        }
    }
}
