using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TODO_List
{
    /// <summary>
    /// A simple todo list created to demonstrate the use of various
    /// controls in Windows Forms C#
    /// </summary>
    public partial class Form1 : Form
    {
        static string _PATH = @System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\TODO List";
        public readonly string PATH = _PATH;
        public string FILEPATH = _PATH + @"\details.txt";
            
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddContent(listBox1, FILEPATH, textBox1.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            RemoveContent(listBox1, FILEPATH, listBox1.SelectedItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
                File.Create(FILEPATH);
            }
            else
            {
                LoadContent(listBox1, FILEPATH);
            }
        }
        void RemoveContent(ListBox listBox, string filePath, object selectedItem)
        {
            listBox.Items.Remove(selectedItem);
            File.WriteAllText(filePath, File.ReadAllText(filePath).Replace(selectedItem.ToString() + "\n", null));
        }
        void AddContent(ListBox listBox, string filePath, string content)
        {
            listBox.Items.Add(content);
            string _CONTENT = content + "\n";
            File.WriteAllText(filePath, File.ReadAllText(filePath) + _CONTENT);
        }
        void LoadContent(ListBox listBox, string filePath)
        {
            foreach (string line in File.ReadAllLines(filePath))
            {
                if (line != null)
                {
                    listBox.Items.Add(line);
                }
            }
        }
    }
}
