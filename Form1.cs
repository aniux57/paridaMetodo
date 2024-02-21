using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa
{
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void btnFrecSimb_Click(object sender, EventArgs e)
        {
        }

        public class m{
            public List<int> linea = new List<int>(); 
            public static List<m> Arraylineas = new List<m>();
        }
        public class iconos
        {
            public string señal { get; set; }
            public int fre { get; set; }
            public string tex { get; set; }
            public static List<iconos> Arrayiconos= new List<iconos>();

            public iconos(string tex)
            {
                this.tex = tex;
            }
        }

        public class Arrayiconos
        {
            public List<iconos> Arrayiconost = new List<iconos>();
            public static List<Arrayiconos> ArrayM =  new List<Arrayiconos>();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            richTBoxIn.Clear();
            richTBoxIn.ReadOnly = false;
            m.Arraylineas.Clear();
        }

        private void label3_Click(object sender, EventArgs e)
        {
           
            richTBoxIn.Clear();
            richTBoxIn.ReadOnly = false;
            m.Arraylineas.Clear();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            richTBoxIn.Clear();
            richTBoxIn.ReadOnly = false;
            m.Arraylineas.Clear();
        }

   

     
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        
        private void panel4_Click(object sender, EventArgs e)
        {
            frecuenicasAsim();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            frecuenicasAsim();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            frecuenicasAsim();
        }

        private void frecuenicasAsim()
        {

            iconos.Arrayiconos.Clear();
            string ArrayIngresa = richTBoxIn.Text;
            if (ArrayIngresa.Length > 0)
            {
                foreach (var y in ArrayIngresa)
                {
                    iconos codigo = iconos.Arrayiconos.Find(x => x.señal == y.ToString());

                    if (codigo == null && y != '\n')
                    {
                        codigo = new iconos();
                        codigo.señal = y.ToString();
                        codigo.fre = 1;
                        codigo.tex = " ";
                        iconos.Arrayiconos.Add(codigo);
                    }
                    else if (codigo != null && y != '\n')
                    {
                        codigo.fre++;
                    }
                }
                iconos.Arrayiconos = iconos.Arrayiconos.OrderByDescending(x => x.fre).ToList();

                dataGVOrdenFrecuencia.DataSource = null;
                dataGVOrdenFrecuencia.Refresh();
                dataGVOrdenFrecuencia.DataSource = iconos.Arrayiconos;
                dataGVOrdenFrecuencia.Refresh();


            }
            else
            {
                MessageBox.Show("PORFAVOR INGRESAR LOS DATOS CORREPSONDIENTES");
            }
        }

        private void Abrir()
        {
            OpenFileDialog o = new OpenFileDialog();
            o.Filter = "rchivos TXT (*.txt)|*.txt|todos los archiovs(*.*)|*.*";
            if (o.ShowDialog() == DialogResult.OK)
            {
                path = o.FileName;

                using (StreamReader sr = new StreamReader(path))
                {
                    string x = sr.ReadToEnd();

                    richTBoxIn.Text = x;
                }
                richTBoxIn.ReadOnly = true;

            }
        }

        private void paridad()
        {
            m matriz = new m();
            string info = richTBoxIn.Text;


            int cont = 0;
            foreach (char bit in info)
            {
                cont++;
                matriz.linea.Add(Convert.ToInt32(bit) - 48);
                if (cont == 7)
                {
                    matriz.linea.Add(vParImpar(matriz.linea.Sum(x => x)));

                    m.Arraylineas.Add(matriz);
                    matriz = new m();
                    cont = 0;
                }
            }
            if (cont > 1)
            {
                m.Arraylineas.Add(matriz);
                matriz.linea.Add(vParImpar(matriz.linea.Sum(x => x)));

                cont = 0;
            }

            matriz = new m();
            for (int i = 0; i < 7; i++)
            {
                int sum = 0;
                foreach (var matrizrecorrido in m.Arraylineas)
                {
                    sum += matrizrecorrido.linea[i];
                }
                matriz.linea.Add(vParImpar(sum));

            }
            matriz.linea.Add(vParImpar(matriz.linea.Sum(x => x)));

            m.Arraylineas.Add(matriz);

        }

        private int vParImpar(int v)
        {
            if (v % 2 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        private void metodoHuffman()
        {
            Arrayiconos listas = new Arrayiconos();
            listas.Arrayiconost = iconos.Arrayiconos.ToList();
            Arrayiconos.ArrayM.Add(listas);

            int couticonos = iconos.Arrayiconos.Count;
            for (int i = 0; i <= couticonos;  i++)
            {
              if (couticonos > 2)
                {
                    iconos.Arrayiconos[couticonos - 2].fre =
                iconos.Arrayiconos[couticonos - 2].fre +
                     iconos.Arrayiconos[couticonos - 1].fre;

                    iconos.Arrayiconos[couticonos - 2].señal =
                   iconos.Arrayiconos[couticonos - 2].señal +
               iconos.Arrayiconos[couticonos - 1].señal;

                    iconos.Arrayiconos.RemoveAt(couticonos - 1);
                    couticonos--;

                    iconos.Arrayiconos = iconos.Arrayiconos.OrderByDescending(x => x.fre).ToList();

                    Arrayiconos tempList = new Arrayiconos();
                    tempList.Arrayiconost = new List<iconos>(iconos.Arrayiconos);
                    Arrayiconos.ArrayM.Add(tempList);
                    MessageBox.Show(Arrayiconos.ArrayM.Count.ToString());
                    dataGVOrdenFrecuencia.DataSource = null;
                    dataGVOrdenFrecuencia.Refresh();
                    dataGVOrdenFrecuencia.DataSource = Arrayiconos.ArrayM[Arrayiconos.ArrayM.Count - 1].Arrayiconost;
                    dataGVOrdenFrecuencia.Refresh();
                }
                
            }


            MessageBox.Show(Arrayiconos.ArrayM.Count.ToString());

            var countListaMayor = Arrayiconos.ArrayM.Count();
            int countLista = 2;
            Arrayiconos.ArrayM[countListaMayor - 1].Arrayiconost[countLista - 2].tex += "0";
            Arrayiconos.ArrayM[countListaMayor - 1].Arrayiconost[countLista - 1].tex += "1";

            for (int i = countListaMayor - 2; i >= 0; i++)
            {
                var Arraynuevo = Arrayiconos.ArrayM[i];
                var Arrayanterior = Arrayiconos.ArrayM[i+1];
                countLista = Arraynuevo.Arrayiconost.Count();

                foreach(var iconoConcat in Arrayanterior.Arrayiconost)
                {
                    foreach(var iconoComparar in Arraynuevo.Arrayiconost)
                    {
                        if (iconoConcat.señal.Contains(iconoComparar.señal))
                        {
                            iconoComparar.tex += iconoConcat.tex;
                        }
                    }                    
                }
            }

        }
        private void panel7_Click(object sender, EventArgs e)
        {

            metodoHuffman();
        }

        private void label5_Click(object sender, EventArgs e)
        {

            metodoHuffman();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

            metodoHuffman();
        }

        
        private void label4_Click(object sender, EventArgs e)
        {
            paridad();
            this.Hide();
            Form formShow = new Formparidad();
            formShow.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void barraAbrir_Paint(object sender, PaintEventArgs e)
        {

        }

        private void barraFrecuencia_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
