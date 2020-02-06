using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace LibraryManagementSystem
{
    public partial class AddingBookForm : Form
    {
        string imgLoc = "";
        string imageURL = null;

        public AddingBookForm()
        {
            InitializeComponent();
        }


        private void AddingBookForm_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e) //Button for submit
        {
            //Converting Image to Byte format 
            byte[] img = null;
            FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            img = br.ReadBytes((int)fs.Length);

            //Calling All methods class to insert books
            //Almethods class has the method for the query 
            AllMethods objMethods = new AllMethods();
            objMethods.Initialize(); //Initializing all method class

           //Taking all the values inside the variables 
            string material = textBox1.Text;
            string source_combo_box = textBox2.Text;
            string supplier_combo_box = textBox3.Text;
            string subject_combo_box = textBox4.Text;
            int shelf_text = Convert.ToInt32(ShelfText.Text); //Converting string to int
            int buying_price = Convert.ToInt32(BuyingPriceText.Text);//Converting string to int
            int selling_price = Convert.ToInt32(SellingPriceText.Text);//Converting string to int
            int numberOfSellableBook = Convert.ToInt32(textBox6.Text);//Converting string to int
            string bookTitle = BookTitleText.Text;
            string authorName = AuthorNameText.Text;
            string subTitle = SubtitleText.Text;
            string isbn = ISBNText.Text;
            int number_of_borrowable_books = Convert.ToInt32(NumberOfBorrowableBooksText.Text);//Converting string to int
            int number_of_readable_books = Convert.ToInt32(readableBooksText.Text);//Converting string to int
            string edition = editionText.Text;

            //calling insert method to insert the books in the database 
            objMethods.Insert(bookTitle, authorName, subTitle, subject_combo_box, isbn, buying_price, selling_price,numberOfSellableBook, shelf_text, number_of_borrowable_books, number_of_readable_books, material, supplier_combo_box, source_combo_box, edition,img,imageURL);

        
            this.Hide(); //Hiding the present page 
            AdminHome admin = new AdminHome(); //Creating new instance of home 
            admin.Show(); // show admin home after pressing submit button
        }

        private void button2_Click(object sender, EventArgs e) //Button for browse images
        {

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Book Picture";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                imgLoc = dlg.FileName.ToString(); //Converting image file location to a string format 
                pictureBox1.Image = Image.FromFile(dlg.FileName);
            }
                 
                
            
        }

        private void button3_Click(object sender, EventArgs e) //Back Button 
        {
            this.Hide();
            AdminHome ah = new AdminHome();
            ah.Show();
        }
    }
}

