using System;
//insertar livbrerias de cpnexion
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guia1_ConexionSql
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAB-C-PC-20\SQLEXPRESS;Initial Catalog=Producto;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
            ObtenerRegistro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=LAB-C-PC-20\SQLEXPRESS;Initial Catalog=Producto;Integrated Security=True");
            conexion.Open();
            MessageBox.Show("Conexión exitosa!!!");
            conexion.Close();
            MessageBox.Show("Conexión cerrada!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text=="" || textBox2.Text=="" || textBox3.Text=="")
                
                    MessageBox.Show("Llene los campos necesario");
                else
                {
                    conn.Open();
                    SqlDataAdapter sda= new SqlDataAdapter("INSERT INTO postres (nombre, precio, stock) VALUES ('"+textBox1.Text+"', '"+textBox2.Text+"','"+textBox3.Text+"')", conn);
                    sda.SelectCommand.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Datos Almacenados Correctamente");
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("Error de SQL Verificar: " + ex.ToString());
                throw;
            }
        }

        private void ObtenerRegistro() 
        { 
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM postres", conn);
            DataSet ds = new DataSet(); 
            da.Fill(ds, "nombre");
            dataGridView1.DataSource = ds.Tables["nombre"].DefaultView;
        }
    }
}
