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
                string fileContent = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                this.TextBlock.Text = fileContent;

                NodeTree tree = new NodeTree(fileContent);
                this.nodeList = tree.GetNodelist();

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Valitse uuden tiedoston tallennuskansio";
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
            string savePath = saveFolder + "\\" + fileName.Split('.')[0] + " ParsingData.pd";
            StreamWriter writer = new StreamWriter(savePath);
            foreach (var item in this.nodeList)
            {
                writer.WriteLine(item.Char.ToString() + " " + item.binary);
            }
            writer.Close();
        }

        private void WriteBinaryfile(string fileName, string saveFolder, string content)
        {
            string savePath = saveFolder + "\\" + fileName.Split('.')[0] + " HuffmanEncoded.txt";

            StreamWriter writer = new StreamWriter(savePath);

            foreach (char Char in content)
            {
                foreach (Node node in nodeList)
                {
                    if(node.Char == Char)
                    {
                        writer.WriteLine(node.binary);
                    }
                }
            }
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Valitse avattava tiedosto";
            ofd.Filter = "Tekstitiedosto (*.txt)|*.txt";
            ofd.ShowDialog();
            if(ofd.FileName != null)
            {
                OpenFileDialog ofd2 = new OpenFileDialog();
                ofd2.Title = "Valitse ohjetiedosto";
                ofd2.Filter = "Aputiedosto (*.pd)|*.pd";
                ofd2.ShowDialog();
                if(ofd2.FileName != null)
                {
                    string[] input = File.ReadAllLines(ofd.FileName);
                    string[] helpData = File.ReadAllLines(ofd2.FileName);
                    StringBuilder sb = new StringBuilder();
                    foreach (string character in input)
                    {
                        foreach (string help in helpData)
                        {
                            if (help.Substring(2) == character)
                            {
                                sb.Append(help[0]);
                            }
                        }
                    }
                    this.TextBlock.Text = sb.ToString();
                }
            }
        }
    }
}
