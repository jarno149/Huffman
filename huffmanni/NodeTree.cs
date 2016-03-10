using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanni
{
    class NodeTree
    {
        public Node Root { get; set; }
        public List<Node> nodes { get; set; }

        public NodeTree(List<Node> nodes)
        {
            this.nodes = nodes;
            Console.WriteLine("\n\n\n");
            CreateTree();
            LevelOrder(this.Root);
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
            if(t.Char != null)
            {
                Console.WriteLine(t.Char + " " + t.RefCount + " " + t.binary);
            }
            else
            {
                Console.WriteLine(t.RefCount);
            }
        }

        // Etsitään jokaiselle kirjaimelle "osoite" jotta se voidaan hakea binääripuusta
        public void LevelOrder(Node node, string binary = "")
        {
            if(node != null)
            {
                if(node.Left != null)
                {
                    node.Left.binary = binary + "0";
                    Visit(node.Left);
                }
                if(node.Right != null)
                {
                    node.Right.binary = binary + "1";
                    Visit(node.Right);
                }

                if(node.Left != null)
                {
                    LevelOrder(node.Left, node.Left.binary);
                }
                if(node.Right != null)
                {
                    LevelOrder(node.Right, node.Right.binary);
                }
            }
        }
    }
}
