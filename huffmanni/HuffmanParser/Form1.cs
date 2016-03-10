using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace HuffmanParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Node> nodeList;

        private void FilePack_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Tekstitiedosto (*.txt)|*.txt";
            ofd.ShowDialog();
            if(ofd.FileName != null)
            {
                string fileContent = File.ReadAllText(ofd.FileName, Encoding.UTF7);
                this.TextBlock.Text = fileContent;

                NodeTree tree = new NodeTree(fileContent);
                this.nodeList = tree.GetNodelist();

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Valitse pakatun tiedoston tallennuskansio";
                fbd.ShowDialog();
                if (fbd.SelectedPath != null)
                {
                    WriteParsingData(ofd.SafeFileName, fbd.SelectedPath);
                    WriteBinaryfile(ofd.SafeFileName, fbd.SelectedPath, fileContent);
                }
            }
        }

        private void WriteParsingData(string fileName, string saveFolder)
        {
            string savePath = saveFolder + "\\" + fileName.Split('.')[0] + " Huffman.txt";
            StreamWriter writer = new StreamWriter(savePath);
            foreach (var item in this.nodeList)
            {
                writer.WriteLine(item.Char.ToString() + " " + item.binary);
            }
            writer.Close();
        }

        private void WriteBinaryfile(string fileName, string saveFolder, string content)
        {
            string savePath = saveFolder + "\\" + fileName.Split('.')[0] + " EncodingData.bin";

            BinaryWriter writer = new BinaryWriter(File.Open(savePath, FileMode.Create));

            foreach (char Char in content)
            {
                foreach (Node node in nodeList)
                {
                    if(node.Char == Char)
                    {
                        byte[] bytes = new byte[node.binary.Length];
                        for (int i = 0; i < node.binary.Length; i++)
                        {
                            bytes[i] = byte.Parse(node.binary[i].ToString());
                        }
                        writer.Write(bytes);
                    }
                }
            }
            writer.Close();
        }
    }
}
