using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanni
{
    class Tree
    {
        public List<TreeNode> nodes { get; set; }
        private string indicator { get; set; }
        public Tree(List<TreeNode> nodes)
        {
            this.indicator = "";
            nodes.Sort();
            this.nodes = nodes;


            Console.WriteLine("\n\n\n");
            foreach (var item in nodes)
            {
                Console.WriteLine(item.References + " " + item.Character);
            }

            CreateTree(null,true);
        }

        public void CreateTree(TreeNode last = null, bool first = false)
        {
            if(first)
            {
                TreeNode node = new TreeNode(this.nodes[0].References + this.nodes[1].References);
                node.Left = this.nodes[0];
                node.Right = this.nodes[1];
                this.nodes.RemoveAt(0);
                this.nodes.RemoveAt(1);
                CreateTree(node, false);
                node.Left.indicator = this.indicator + "0";
                node.Right.indicator = this.indicator + "1";
            }

            if (last != null && !first)
            {
                TreeNode node = new TreeNode(this.nodes[0].References + last.References);
                if(last.References < nodes[0].References)
                {
                    node.Left = last;
                    node.Left.indicator = this.indicator + "0";
                    node.Right = nodes[0];
                    node.Right.indicator = this.indicator + "1";
                }
                else
                {
                    node.Left = nodes[0];
                    node.Right = last;
                }
                this.nodes.RemoveAt(0);
                if(this.nodes.Count > 0)
                {
                    CreateTree(node, false);
                }
            }
        }
    }
}
