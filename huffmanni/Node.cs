using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanni
{
    class Node : IComparable<Node>
    {

        // Merkin oikealla puolella sijaitseva node
        public Node Right { get; set; }

        // Merkin vasemmalla puolella sijaitseva node
        public Node Left { get; set; }

        // Merkki
        public char Char { get; set; }

        // Määrä kuinka monta kertaa kirjain esiintyy
        public int RefCount { get; set; }

        public string binary { get; set; }

        public Node(char Char, int Ref)
        {
            this.Char = Char;
            this.RefCount = Ref;
        }

        public Node(int Ref)
        {
            this.RefCount = Ref;
        }

        // CompareTo metodi jolla järjestetään nodet niiden ilmestymismäärän perusteella
        public int CompareTo(Node node)
        {
            int cmp = this.RefCount.CompareTo(node.RefCount);
            if (cmp == 0)
            {
                cmp = node.Char.CompareTo(this.Char);
            }
            return cmp;
        }
    }
}
