using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddBookApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            FormSets();
            FillGrid();
        }

        public void FormSets() 
        {
            this.Height = 500;
            this.Width = 700;
        }

        public void FillGrid() 
        {
            DB db = new DB();
            DataTable table = new DataTable();
            int amount;
            try
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM `books` WHERE `reserved` = 1", db.getConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(table);

                amount = table.Rows.Count;
                Book[] books = new Book[amount];

                for (int i = 0; i < amount; i++)
                {
                    string[] str = {
                            Convert.ToString(table.Rows[i].ItemArray[0]),
                            Convert.ToString(table.Rows[i].ItemArray[1]),
                            Convert.ToString(table.Rows[i].ItemArray[2]),
                            Convert.ToString(table.Rows[i].ItemArray[3]),
                            Convert.ToString(table.Rows[i].ItemArray[4]),
                    };

                    //books[i] = new Book(
                    //        Convert.ToString(table.Rows[i].ItemArray[1]),
                    //        Convert.ToString(table.Rows[i].ItemArray[2]),
                    //        Convert.ToInt32(table.Rows[i].ItemArray[3]),
                    //        Convert.ToString(table.Rows[i].ItemArray[4]),
                    //        Convert.ToBoolean(table.Rows[i].ItemArray[5]
                    //        ));
                    DG.Rows.Add(str);
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
