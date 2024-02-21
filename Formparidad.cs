using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Codificacion.Form1;

namespace Codificacion
{
    public partial class Formparidad : Form
    {
        public Formparidad()
        {
            InitializeComponent();
        }

        private void FormParidadCruzada_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            listViewMatriz.Clear();
            listViewMatriz.Items.Add("xxxxxxxP");

            foreach (var matrizrecorrido in m.Arraylineas)
            {
                string cadena = "";
                foreach (var b in matrizrecorrido.linea)
                {
                    cadena += (b).ToString();
                }
                listViewMatriz.Items.Add(cadena);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void FormParidadCruzada_Shown(object sender, EventArgs e)
        {
            
        }
    }
}
