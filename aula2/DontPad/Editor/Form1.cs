using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbTexto.ZoomFactor += 1f;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbTexto.Text = "";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rtbTexto.Undo();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();

            var path = saveFileDialog1.FileName;
            
            if(path != "")
                rtbTexto.SaveFile(path, RichTextBoxStreamType.PlainText);

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            open.ShowDialog();


            var fileContent = string.Empty;
            var fileStream = open.OpenFile();

            StreamReader reader = new StreamReader(fileStream);
            fileContent = reader.ReadToEnd();
            rtbTexto.Text = fileContent;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowDialog();

            rtbTexto.SelectionFont = fontDialog.Font;
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            rtbTexto.SelectionColor = colorDialog.Color;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbTexto.ZoomFactor -= 1f;
        }

        private void restoreDefaultZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbTexto.ZoomFactor = 1;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            printDialog.ShowDialog();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog();

            pageSetupDialog.ShowDialog();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbTexto.WordWrap == true)
                rtbTexto.WordWrap = false;
            else
                rtbTexto.WordWrap = true;
        }
    }
}