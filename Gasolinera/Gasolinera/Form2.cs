using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gasolinera
{
    public partial class Form2 : Form
    {
        public event Action<double> GalonesDespachados;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double cantidadDespachada))
            {
                GalonesDespachados?.Invoke(cantidadDespachada);
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida.");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}