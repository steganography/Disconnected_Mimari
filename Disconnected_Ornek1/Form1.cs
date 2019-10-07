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

namespace Disconnected_Ornek1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection("server=.; Database=Northwind007; uid=sa; pwd=123");
        }

        SqlConnection con;

        private void BtnDataSet_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select top 9 * from Employees",con);
            DataSet ds = new DataSet();
            da.Fill(ds,"personeller");

            dgwListe.DataSource = ds.Tables["personeller"];

        }

        private void BtnDataTable_Click(object sender, EventArgs e)
        {//  Select * from categories
            SqlDataAdapter da = new SqlDataAdapter("Select * from categories",con);
            DataTable dt = new DataTable();

            da.Fill(dt);
            dgwListe.DataSource = dt;

        }
    }
}
