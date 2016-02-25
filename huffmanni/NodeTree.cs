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

        private string binary { get; set; }
        public NodeTree(List<Node> nodes)
        {
            this.binary = " ";
            this.nodes = nodes;
            CreateTree2();
            Console.WriteLine("\n\n\n");
            //TraversePreorder(this.Root);
            TraverseLevelOrder(this.Root);
        }

        private void CreateTree2(Node last = null, Node second = null)
        {
            if(last == null && this.nodes.Count > 0)
            {
                Node rootNode = new Node(nodes[0].RefCount + nodes[1].RefCount);
                if(nodes[0].RefCount < nodes[1].RefCount)
                {
                    rootNode.Left = nodes[0];
                    rootNode.Right = nodes[1];
                }
                else
                {
                    rootNode.Right = nodes[0];
                    rootNode.Left = nodes[1];
                }
                nodes.RemoveRange(0,2);
                CreateTree2(rootNode);
            }
            else if(second != null && last != null)
            {
                this.Root = new Node(second.RefCount + last.RefCount);
                if(second.RefCount < last.RefCount)
                {
                    this.Root.Left = second;
                    this.Root.Right = last;
                }
                else
                {
                    this.Root.Left = last;
                    this.Root.Right = second;
                }
            }
            else
            {
                while (this.nodes.Count > 0)
                {
                    Node rootNode = new Node(nodes[0].RefCount + last.RefCount);
                    if (nodes[0].RefCount < last.RefCount)
                    {
                        rootNode.Left = nodes[0];
                        rootNode.Right = last;
                    }
                    else
                    {
                        rootNode.Right = nodes[0];
                        rootNode.Left = last;
                    }
                    if(nodes.Count == 1)
                    {
                        nodes.RemoveAt(0);
                        this.Root = rootNode;
                    }
                    else
                    {
                        nodes.RemoveAt(0);
                        CreateTree2(rootNode);
                    }
                    
                }
            }
        }

        private void CreateTree(Node last = null, Node sec = null)
        {
            if(last == null)
            {
                Node latestRoot = new Node(nodes[0].RefCount + nodes[1].RefCount);
                latestRoot.Left = nodes[0];
                latestRoot.Right = nodes[1];
                nodes.RemoveAt(0);
                nodes.RemoveAt(0);

                CreateTree(latestRoot);
            }
            else
            {
                while (this.nodes.Count > 1)
                {
                    // muutos
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
                    Node tmp2 = nodes[0];
                    
                    
                    if(nodes.Count == 0)
                    {
                        nodes.RemoveAt(0);
                        CreateTree(last, tmp2);
                    }
                    else
                    {
                        nodes.RemoveAt(1);
                        CreateTree(tmp);
                    }
                }
                if(last != null && sec != null)
                {
                    Node node = new Node(last.RefCount + sec.RefCount);
                    if(last.RefCount < sec.RefCount)
                    {
                        node.Left = last;
                        node.Right = sec;
                    }
                    else
                    {
                        node.Left = sec;
                        node.Right = last;
                    }
                    CreateTree(node);
                }

                if(this.nodes.Count == 1)
                {
                    this.Root = new Node(last.RefCount + nodes[0].RefCount);
                    if(last.RefCount > nodes[0].RefCount)
                    {
                        this.Root.Left = nodes[0];
                        this.Root.Right = last;
                    }
                    else
                    {
                        this.Root.Left = last;
                        this.Root.Right = nodes[0];
                    }
                    this.nodes.RemoveAt(0);
                }
            }
        }

        public void TraversePreorder(Node t)
        {
            if (t != null)
            {
                
                Visit(t);
                if(t.Left != null)
                {
                    this.binary += "0";
                    t.Left.binary = this.binary;
                    TraversePreorder(t.Left);
                }

                if (t.Right != null)
                {
                    this.binary = this.binary.Remove(this.binary.Length - 1, 1);
                    this.binary += "1";
                    t.Right.binary = this.binary;
                }
                   
                TraversePreorder(t.Right);
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

        int calc = 0;

        public void TraverseLevelOrder(Node t)
        {
            
            if (t != null)
            {
                calc++;
                if(t.Left != null)
                {
                    t.Left.binary = this.binary + "0";
                    Visit(t.Left);
                }
                if(t.Right != null)
                {
                    t.Right.binary = this.binary + "1";
                    Visit(t.Right);
                }

                this.binary = this.binary.Remove(0, calc);
                this.binary += "0";
                TraverseLevelOrder(t.Left);

                this.binary = this.binary.Remove(0, calc);
                this.binary += "1";
                TraverseLevelOrder(t.Right);
            }
        }
    }
}
