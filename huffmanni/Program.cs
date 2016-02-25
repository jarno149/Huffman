using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanni
{
    class Program
    {
        // testi
        static void Main(string[] args)
        {
            string nimi = "AAAAABBBBCCD";

             List<Node> nodes = LetterCount(nimi);
             nodes.Sort();

             foreach (Node node in nodes)
             {
                 Console.WriteLine(node.Char + " " + node.RefCount);
             }

             NodeTree tree = new NodeTree(nodes);
        }


        /// <summary>
        /// Luetaan kunkin tekstissä esiintyvän kirjaimen lukumäärä
        /// </summary>
        /// <param name="text">Teksti</param>
        public static List<Node> LetterCount(string text)
        {
            List<Node> nodes = new List<Node>();

            for (int i = 32; i <= 255; i++)
            {
                int count = 0;
                for (int j = 0; j < text.Length; j++)
                {
                    if(Convert.ToChar(i) == text[j])
                    {
                        count++;
                    }
                }
                if(count != 0)
                {
                    Console.WriteLine(count + " " + Convert.ToChar(i));
                    Node node = new Node(Convert.ToChar(i), count);
                    nodes.Add(node);
                }
            }
            return nodes;
        }
    }
}
