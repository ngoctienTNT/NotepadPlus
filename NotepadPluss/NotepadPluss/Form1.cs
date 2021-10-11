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


namespace NotepadPluss
{
    public partial class Form1 : Form
    {
        private string fileName;
        private bool check = true;
        public Form1()
        {
            InitializeComponent();
            fileName = "";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lập trình bởi Trần Ngọc Tiến\nPhiên bản 1.0.0", "About Notepad Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool control = true;
            if ((fileName == "" && rTbMain.Text != "") || (fileName != "" && check == false))
            {
                DialogResult result;
                result = MessageBox.Show("Bạn có muốn lưu nội dung lại không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                if (result == DialogResult.Yes)
                {
                    if (fileName == "")
                    {
                        FileDialog dialog = new SaveFileDialog();
                        dialog.Filter = "Text|*.txt";
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(dialog.FileName);
                            writer.Write(rTbMain.Text);
                            writer.Close();
                        }
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(fileName);
                        writer.WriteLine(rTbMain.Text);
                        writer.Close();
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    control = false;
                }
            }
            if (control == false) return;
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Text|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = fileDialog.FileName;
                this.Text = Path.GetFileName(fileName) + " - Notepad Plus";
                StreamReader reader = new StreamReader(fileDialog.FileName);
                rTbMain.Text = reader.ReadToEnd();
                reader.Close();
            }
            check = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (fileName == "") 
            {
                FileDialog fileDialog = new SaveFileDialog();
                fileDialog.Filter = "Text|*.txt";
                if (fileDialog.ShowDialog()==DialogResult.OK)
                {
                    StreamWriter writer = new StreamWriter(fileDialog.FileName);
                    writer.Write(rTbMain.Text);
                    writer.Close();
                    fileName = fileDialog.FileName;
                    this.Text = Path.GetFileName(fileName) + " - Notepad Plus";
                }    
            }    
            else
            {
                StreamWriter writer = new StreamWriter(fileName);
                writer.WriteLine(rTbMain.Text);
                writer.Close();
            }
            check = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Text|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(fileDialog.FileName);
                writer.Write(rTbMain.Text);
                writer.Close();
                fileName = fileDialog.FileName;
                this.Text = Path.GetFileName(fileName) + " - Notepad Plus";
            }
            check = true;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {    
            if ((fileName == "" && rTbMain.Text != "") || (fileName != "" && check == false))
            {
                bool kt = false;
                DialogResult result;
                result = MessageBox.Show("Bạn có muốn lưu nội dung lại không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                if (result == DialogResult.Yes)
                {
                    if (fileName == "")
                    {
                        FileDialog fileDialog = new SaveFileDialog();
                        fileDialog.Filter = "Text|*.txt";
                        if (fileDialog.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(fileDialog.FileName);
                            writer.Write(rTbMain.Text);
                            writer.Close();
                            kt = true;
                        }
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(fileName);
                        writer.WriteLine(rTbMain.Text);
                        writer.Close();
                        kt = true;
                    }
                    if (kt)
                    {
                        check = true;
                        rTbMain.Text = "";
                        fileName = "";
                        this.Text = "New Notepad Plus - TNT";
                    }
                }
                else if (result == DialogResult.No)
                {
                    rTbMain.Text = "";
                    fileName = "";
                    this.Text = "New Notepad Plus - TNT";

                }
            }  
            else
            {
                rTbMain.Text = "";
                fileName = "";
                this.Text = "New Notepad Plus - TNT";
                check = true;
            }    
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((fileName == "" && rTbMain.Text != "") || (fileName != "" && check == false))
            {
                bool kt = false;
                DialogResult result;
                result = MessageBox.Show("Bạn có muốn lưu nội dung lại không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
                if (result == DialogResult.Yes)
                {
                    if (fileName == "")
                    {
                        FileDialog fileDialog = new SaveFileDialog();
                        fileDialog.Filter = "Text|*.txt";
                        if (fileDialog.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(fileDialog.FileName);
                            writer.Write(rTbMain.Text);
                            writer.Close();
                            kt = true;
                        }
                    }
                    else
                    {
                        StreamWriter writer = new StreamWriter(fileName);
                        writer.WriteLine(rTbMain.Text);
                        writer.Close();
                        kt = true;
                    }
                    if (kt == false) e.Cancel = true;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void rTbMain_TextChanged(object sender, EventArgs e)
        {
            check = false;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK) rTbMain.Font = fontDialog.Font;
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK) rTbMain.ForeColor = colorDialog.Color;
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK) rTbMain.BackColor = colorDialog.Color;
        }
    }
}
