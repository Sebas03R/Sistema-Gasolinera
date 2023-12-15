using System;
using System.Windows.Forms;

namespace Gasolinera
{
    public partial class Form1 : Form
    {
        private BombaGasolina bomba;

        public Form1()
        {
            InitializeComponent();
            bomba = new BombaGasolina();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MostrarFormulario("Regular", 2.00);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MostrarFormulario("Premium", 2.50);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarFormulario("Súperpremium", 5.80);
        }

        private void MostrarFormulario(string tipoGasolina, double precioPorGalon)
        {
            Form2 form2 = new Form2();

            form2.GalonesDespachados += (galones) =>
            {
                double cantidadDespachada = bomba.DespacharGasolina(tipoGasolina, galones);
                double precioTotal = cantidadDespachada * precioPorGalon;

                textBox1.Text = cantidadDespachada.ToString();
                textBox2.Text = precioTotal.ToString("C"); 
            };

            form2.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }

    public class BombaGasolina
    {
        private const double CapacidadTanque = 500;
        private const double CantidadInicial = 300;

        private double cantidadRegular;
        private double cantidadPremium;
        private double cantidadSuperpremium;

        public BombaGasolina()
        {
            cantidadRegular = CantidadInicial;
            cantidadPremium = CantidadInicial;
            cantidadSuperpremium = CantidadInicial;
        }

        public double DespacharGasolina(string tipoGasolina, double cantidadSolicitada)
        {
            double cantidadDespachada = 0;

            switch (tipoGasolina)
            {
                case "Regular":
                    cantidadDespachada = Math.Min(cantidadSolicitada, cantidadRegular);
                    cantidadRegular -= cantidadDespachada;
                    break;

                case "Premium":
                    cantidadDespachada = Math.Min(cantidadSolicitada, cantidadPremium);
                    cantidadPremium -= cantidadDespachada;
                    break;

                case "Súperpremium":
                    cantidadDespachada = Math.Min(cantidadSolicitada, cantidadSuperpremium);
                    cantidadSuperpremium -= cantidadDespachada;
                    break;
            }

            return cantidadDespachada;
        }
    }
}