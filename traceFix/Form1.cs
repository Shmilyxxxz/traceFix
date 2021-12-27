using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using ASM.TraceabilityProxy.Service;
namespace traceFix
{
    public partial class Form1 : Form
    {
        private List<string> barCodeList = new List<string>();
        private List<string> fileList = new List<string>();
        private string Dictionary = string.Empty;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog_SourceFile_FileOk(object sender, CancelEventArgs e)
        {

            if (fileList.Count!=0)
                fileList.Clear();
            fileList = openFileDialog_SourceFile.FileNames.ToList();

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = fileList.Count()* barCodeList.Count();
            label4.Text = progressBar1.Maximum.ToString();

            for (int i=0;i <fileList.Count();i++)
            {
                ConverTraceFile(fileList[i]);
            }
            ///
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog_SourceFile.ShowDialog();
        }


        private void ConverTraceFile(string filePath)
        {
            FileStream fs = File.Open(filePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(TraceabilityData));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            TraceabilityData data = new TraceabilityData(); 
            data = (TraceabilityData)serializer.Deserialize(fs);

            string OldFileName = Path.GetFileName(filePath);
            int n1 = OldFileName.IndexOf("_");
            int n2 = OldFileName.LastIndexOf("-");
            string oldbarcode = OldFileName.Substring(n1 + 1, n2 - n1 - 1);

            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                foreach (var barcode in barCodeList)
                {
                    string NewFileName = OldFileName.Replace(oldbarcode, barcode);
                    string newFilePath = Dictionary + "\\" + NewFileName;
                    data.boardID = barcode;
                    data.panels[0].panelID = barcode;
                    using (FileStream stream = File.Create(newFilePath))
                    {
                        serializer.Serialize(stream, data,ns);
                    }
                    progressBar1.PerformStep();
                    label3.Text = progressBar1.Value.ToString();
                }
            }
            

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {

                Dictionary = folderBrowserDialog1.SelectedPath;
                textBox2.Text = Dictionary;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            barCodeList.Clear();
            if (openFileDialog_barcodeFile.ShowDialog() == DialogResult.OK)
            {
                barCodeList = File.ReadLines(openFileDialog_barcodeFile.FileName).ToList();
            }
            textBox3.Text = openFileDialog_barcodeFile.FileName;
        }
    }
}
