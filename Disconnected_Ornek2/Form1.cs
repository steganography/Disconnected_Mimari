using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Disconnected_Ornek2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        SqlConnection con;
        SqlDataAdapter da;
        DataTable dt;

        private void Form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=.; database=Northwind007; uid=sa; pwd=123");
            da = new SqlDataAdapter("select * from Shippers", con);//5




        }

        void ListeyiDoldur()
        {
            dt = new DataTable();
            da.Fill(dt);
            dgv.DataSource = dt;


        }

        private void BtnKargoListele_Click(object sender, EventArgs e)
        {
            ListeyiDoldur();
        }

        private void TsmSenkron_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Güncelleme yapmak istediğinize emin misiniz?\n Dikkat bu işlem geri alınamaz!", "Güncelleme Uyarısı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                // SqlCommandBuilder: Bir Dataset ya da DataTable üzerinde yapılan tüm değişiklikleri veritabanına gönderip işlemekle sorumlu nesnedir. 
                // Bu sayede bizi özel bir insert, update, ya da delete işlemi yapmaktan kurtarır.
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(dt);
                
            }
            else
            {
                MessageBox.Show("İsteğiniz Doğrultusunda güncelleme işlemi iptal edildi!");
            }

            ListeyiDoldur();


        }
    }
}
