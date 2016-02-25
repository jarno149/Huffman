using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace huffmanni
{
    class TreeNode : IComparable<TreeNode>
    {
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public char Character { get; set; }
        public int References { get; set; }

        public string indicator { get; set; }

        public TreeNode(char Character, int References)
        {
            this.Character = Character;
            this.References = References;
        }

        public TreeNode(int References)
        {
            this.References = References;
        }

        public int CompareTo(TreeNode node)
        {
            int cmp = this.References.CompareTo(node.References);
            if(cmp == 0)
            {
                cmp = node.Character.CompareTo(this.Character);
            }
            return cmp;
        }
    }
}
