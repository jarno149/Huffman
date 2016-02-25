using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanni
{
    class Program
    {
        static void Main(string[] args)
        {
            string nimi = "jarno rajala";

             List<TreeNode> nodes = LetterCount(nimi);

             Tree tree = new Tree(nodes);
        }


        /// <summary>
        /// Luetaan kunkin tekstissä esiintyvän kirjaimen lukumäärä
        /// </summary>
        /// <param name="text">Teksti</param>
        public static List<TreeNode> LetterCount(string text)
        {
            List<TreeNode> nodes = new List<TreeNode>();

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
                    TreeNode node = new TreeNode(Convert.ToChar(i), count);
                    nodes.Add(node);
                }
            }
            return nodes;
        }
    }
}
