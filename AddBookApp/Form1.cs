using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ExcelDataReader;
using MySql.Data.MySqlClient;

namespace AddBookApp
{
    public partial class Form1 : Form
    {
        private string FileName = String.Empty;
        private DataTableCollection tableCollection = null;

        Font btFont;
        Font lbFont;

        public Form1()
        {
            InitializeComponent();
            FormSets(); 
            LoadFont();
        }

        public void FormSets() 
        {
            this.Size = new Size(550, 400);
            appPanel.Height = 70;
            appPanel.BackColor = Color.FromArgb(243, 165, 5);

            addButton.Location = new Point(100, 230);
            requestButton.Location = new Point(380 - requestButton.Width, 230);

            addButton.BackColor = Color.FromArgb(243, 165, 5);
            requestButton.BackColor = Color.FromArgb(243, 165, 5);

            addButton.Size = new Size(130, 40); 
            requestButton.Size = new Size(130, 40);

            appLabel.Width = 450;
            appLabel.Text = "БИБЛИОТЕКАРЬ";
        }

        public void LoadFont() 
        {
            PrivateFontCollection custom_font = new PrivateFontCollection();
            custom_font.AddFontFile("font.ttf");


            btFont = new Font(custom_font.Families[0], 14);
            lbFont = new Font(custom_font.Families[0], 23);

            requestButton.Font = btFont;
            addButton.Font = btFont;
            appLabel.Font = lbFont;

            appLabel.ForeColor = Color.White;
            requestButton.ForeColor = Color.White;
            addButton.ForeColor = Color.White;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = "c:\\";
                ofd.Filter = "xlsx files (*.xlsx)|*.xlsx";
                ofd.FilterIndex = 2;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileName = ofd.FileName;

                    Text = FileName;
                    OpenExcelFile(Text);
                    DataRowCollection dataRows = tableCollection[0].Rows;
                    Book[] books = new Book[dataRows.Count];
                    for (int i = 0; i < dataRows.Count; i++) 
                    {
                        DataRow dr = dataRows[i];
                        books[i] = new Book(
                            Convert.ToString(dr.ItemArray[1]),
                            Convert.ToString(dr.ItemArray[2]),
                            Convert.ToInt32(dr.ItemArray[3]), 
                            Convert.ToString(dr.ItemArray[4]), 
                            Convert.ToBoolean(dr.ItemArray[5]
                            ));
                    }
                    addBooks(books, db);
                    MessageBox.Show("Все прошло успешно!!!");
                }
                else 
                {
                    throw new Exception("Файл не выбран");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

        private void OpenExcelFile(string path) 
        {
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            DataSet exD = reader.AsDataSet( new ExcelDataSetConfiguration() 
            { 
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration() 
                { 
                    UseHeaderRow = true
                }
            });

            tableCollection = exD.Tables;
        }

        private void requestButton_Click(object sender, EventArgs e)
        {

            Form form = new Form2();
            form.Show();
        }
    }
}
