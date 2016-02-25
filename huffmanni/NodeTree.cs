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
            CreateTree();
        }

        private void CreateTree(Node last = null)
        {
            if(last == null)
            {
                Node latestRoot = new Node(nodes[0].RefCount + nodes[1].RefCount);
                latestRoot.Left = nodes[0];
                latestRoot.Right = nodes[1];
                nodes.RemoveAt(0);
                nodes.RemoveAt(1);

                CreateTree(latestRoot);
            }
            else
            {
                while (this.nodes.Count > 1)
                {
                    if(last.RefCount < nodes[0].RefCount)
                    {
                        nodes[1].Left = last;
                        nodes[1].Right = nodes[0];
                    }
                    else
                    {
                        nodes[1].Right = last;
                        nodes[1].Left = nodes[0];
                    }
                    Node tmp = nodes[1];
                    nodes.RemoveAt(0);
                    nodes.RemoveAt(1);
                    CreateTree(tmp);
                }
                if(this.nodes.Count == 1)
                {
                    this.Root = new Node(last.RefCount + nodes[0].RefCount);
                    if(last.RefCount < nodes[0].RefCount)
                    {
                        this.Root.Left = last;
                        this.Root.Right = nodes[0];
                        this.nodes.RemoveAt(0);
                    }
                }
            }
        }
    }
}
