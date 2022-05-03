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

namespace AddBookApp
{
    public partial class addBookForm : Form
    {
        public addBookForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string str = "keokre;okrj;e \n l;wlew;'le';w \n elwplke[w'w ";
            //string filePath;
            //string books = "";
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.InitialDirectory = "c:\\";
            //ofd.Filter = "docx files (*.docx)|*.docx|All files (*.*)|*.*";
            //ofd.FilterIndex = 2;
            //ofd.RestoreDirectory = true;

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    filePath = ofd.FileName;

            //    string[] readText = File.ReadAllLines(filePath);
            //    foreach (string s in readText)
            //    {
            //        books += s;
            //    }
            //    MessageBox.Show(books);

            //}
            //string[] f = cutString(str);
            //for (int i = 0; i < f.Length; i++) 
            //{
            //    MessageBox.Show(f[i]);
            //}
            DB db = new DB();
        }

        private string[] cutString(string str) 
        {
            string[] s = str.Split('\n');
            return s;
        }

        private void addBooks(Book[] b, DB db) 
        {
            foreach (Book book in b) 
            {
                if (!book.addBookInDb(db)) 
                {
                    MessageBox.Show("Something was flase");
                    break;
                }
                    
            }
        }
    }
}
