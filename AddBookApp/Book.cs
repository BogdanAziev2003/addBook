using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddBookApp
{
    class Book
    {
        public string Name;
        public int Age;
        public string Description;
        public string Author;
        public bool Reserved;

        public Book(string bookName, string bookAuthor, int bookAge, string bookDescription, bool bookReserved) 
        {
            Name = bookName;
            Age = bookAge;
            Description = bookDescription;
            Reserved = bookReserved;
            Author = bookAuthor;
        }

        public bool addBookInDb(DB db) 
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `books`(`name`, `age`, `description`, `reserved`, `author`) VALUES (@name, @age, @description, @reserved, @author)", db.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = Name;
            command.Parameters.Add("@age", MySqlDbType.Int32).Value = Age;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = Description;
            command.Parameters.Add("@author", MySqlDbType.VarChar).Value = Author;
            command.Parameters.Add("@reserved", MySqlDbType.Bit).Value = Reserved;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1) 
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
    }
}
