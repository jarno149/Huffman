using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanParser
{
    class NodeTree
    {
        private Node Root { get; set; }
        private List<Node> nodes { get; set; }

        public NodeTree(string text)
        {
            CountLetters(text);
            CreateTree();
            CreateBinarys(this.Root);
            this.nodes.Clear();
            CreateNodeList(this.Root);
        }

        private void CountLetters(string text)
        {
            this.nodes = new List<Node>();
            for (int i = 32; i <= 255; i++)
            {
                int count = 0;
                for (int j = 0; j < text.Length; j++)
                {
                    if (Convert.ToChar(i) == text[j])
                    {
                        count++;
                    }
                }
                if (count != 0)
                {
                    Console.WriteLine(count + " " + Convert.ToChar(i));
                    Node node = new Node(Convert.ToChar(i), count);
                    nodes.Add(node);
                }
            }
        }

        private void CreateTree()
        {
            while (nodes.Count > 1)
            {
                List<Node> orderedNodes = nodes.OrderBy(node => node.RefCount).ToList<Node>();

                if (orderedNodes.Count >= 2)
                {
                    // Otetaan kaksi ensimmäistä nodea listasta
                    List<Node> taken = orderedNodes.Take(2).ToList<Node>();

                    Node parent = new Node(taken[0].RefCount + taken[1].RefCount);
                    parent.Left = taken[0];
                    parent.Right = taken[1];


                    nodes.Remove(taken[0]);
                    nodes.Remove(taken[1]);
                    nodes.Add(parent);
                }
                this.Root = nodes.FirstOrDefault();
            }
        }
        private void Visit(Node t)
        {
            if (t.Char != null)
            {
                Console.WriteLine(t.Char + " " + t.RefCount + " " + t.binary);
            }
            else
            {
                Console.WriteLine(t.RefCount);
            }
        }

        // Etsitään jokaiselle kirjaimelle "osoite" jotta se voidaan hakea binääripuusta
        private void CreateBinarys(Node node, string binary = "")
        {
            if (node != null)
            {
                if (node.Left != null)
                {
                    node.Left.binary = binary + "0";
                    Visit(node.Left);
                }
                if (node.Right != null)
                {
                    node.Right.binary = binary + "1";
                    Visit(node.Right);
                }

                if (node.Left != null)
                {
                    CreateBinarys(node.Left, node.Left.binary);
                }
                if (node.Right != null)
                {
                    CreateBinarys(node.Right, node.Right.binary);
                }
            }
        }

        private void CreateNodeList(Node node)
        {
            if (node != null)
            {
                if(node.Char != null && node.Char != '\0')
                {
                    this.nodes.Add(node);
                }
                if (node.Left != null)
                {
                    CreateNodeList(node.Left);
                }
                if (node.Right != null)
                {
                    CreateNodeList(node.Right);
                }
            }
        }

        public List<Node> GetNodelist()
        {
            return this.nodes;
        }
    }
}
