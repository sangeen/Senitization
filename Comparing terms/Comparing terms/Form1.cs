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
using System.Text.RegularExpressions;

using System.Data.SqlClient;

namespace Comparing_terms
{
    public partial class Form1 : Form
    {
        string connetionString = "Data Source=SANGEEN-PC;Initial Catalog=IS_Project;Integrated Security=True;Connection Timeout=0";


        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                    try
                    {
                        cnn.Open();
                        MessageBox.Show("ConnetionString is working Fine");
                        cnn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Can not open connection ! ");
                    }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            /*
            string connetionString = "Data Source=SANGEEN-PC;Initial Catalog=IS_Project;Integrated Security=True;Connection Timeout=0";
            using (SqlConnection cnn = new SqlConnection(connetionString))
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("select NamesValues from Names", cnn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Names");

                    
                    foreach (DataRow row in ds.Tables["Names"].Rows)
                    {
                        Names.Add(row["NamesValues"].ToString());
                    }
                    listBox1.DataSource = Names;
                    int a = Names.Count;
                    MessageBox.Show("Numbers of Items add to the list is :", a.ToString());
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Can not open connection ! ");
                }
            */

            List<string> Names = new List<string>();
            Names.Add("Sangeen Khan");
            Names.Add("Jhon");
            Names.Add("Wasim");
            Names.Add("Alexander");
            Names.Add("Afridi");
            listBox1.DataSource = Names;
            string Text = System.IO.File.ReadAllText(@"D:\Data-Sanitization-Project\Files\Test.txt");

            List<string> matchedWords = Names.Where(Text.Contains).ToList();
            matchedWords.ForEach(w => Text = Text.Replace(w, "Names"));
            int numMatchedWords = matchedWords.Count;

            listBox2.DataSource = matchedWords;
            textBox3.Text = Text;
            MessageBox.Show(numMatchedWords.ToString());
        }
              public static Dictionary<string, int> OccurencesInText(this IEnumerable<string> words, string text, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            Dictionary<string, int> resultDict = new Dictionary<string, int>();
            foreach (string word in words.Distinct())
            {
                int wordOccurrences = 0;
                for (int i = 0; i < text.Length - word.Length; i++)
                {
                    string substring = text.Substring(i, word.Length);
                    if (substring.Equals(word, comparison)) wordOccurrences++;
                }
                resultDict.Add(word, wordOccurrences);
            }
            return resultDict;
        }



        




        }


        private void button4_Click(object sender, EventArgs e)
        {






        }






        private void button3_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"D:\Data-Sanitization-Project\Files\Test.txt");

            textBox1.Text = text;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
