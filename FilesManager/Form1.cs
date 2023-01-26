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

namespace FilesManager
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();

                DirectoryInfo directory = new DirectoryInfo(textBox1.Text);

                DirectoryInfo[] directories = directory.GetDirectories();
                foreach (DirectoryInfo dirs in directories)
                {
                    listBox1.Items.Add(dirs);
                }

                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    listBox1.Items.Add(file);
                }
            }
            catch 
            {
                MessageBox.Show("Неверно указан путь.", "Сообщение об ошибке",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = Path.Combine(textBox1.Text, listBox1.SelectedItem.ToString());

            listBox1.Items.Clear();

            DirectoryInfo directory = new DirectoryInfo(textBox1.Text);

            DirectoryInfo[] directories = directory.GetDirectories();
            foreach (DirectoryInfo dirs in directories)
            {
                listBox1.Items.Add(dirs);
            }

            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                listBox1.Items.Add(file);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pathText = textBox1.Text;
            string newPathText = pathText.Substring(0, pathText.LastIndexOf('\\'));
            textBox1.Text = newPathText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox1.Text == "C:\\")
            {
                MessageBox.Show("Здесь нельзя содать папку.",
                    "Ошибка создания папки",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                string pathFile = Path.GetFullPath(textBox1.Text);
                string fileName = textBox2.Text;
                FileCreator fileCreator = new FileCreator(pathFile, fileName);
                fileCreator.CreateFile();
                MessageBox.Show("Файл успешно создан!",
                    "Успешно",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void aboutProgrammToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgrammWindow aboutWindow = new AboutProgrammWindow();
            aboutWindow.Show();
        }
    }
}
