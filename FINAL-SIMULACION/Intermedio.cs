using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FINAL_SIMULACION
{
    public partial class Intermedio : Form
    {
        string tipo_iteracion;
        int cantidad_iteraciones;
        int cantidad_pacientes_diarios;
        int cantidad_minutos_entre_pacientes;
        bool mostrar_pacientes;
        public Intermedio(string tipo_iteracion, int cantidad_iteraciones, int cantidad_pacientes_diarios, int cantidad_minutos_entre_pacientes, bool mostrar_pacientes)
        {
            this.tipo_iteracion = tipo_iteracion;
            this.cantidad_iteraciones = cantidad_iteraciones;
            this.cantidad_pacientes_diarios = cantidad_pacientes_diarios;
            this.cantidad_minutos_entre_pacientes = cantidad_minutos_entre_pacientes;
            this.mostrar_pacientes = mostrar_pacientes;
            InitializeComponent();
        }

        private void btn_cerrar_programa_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_reformular_llegadas_Click(object sender, EventArgs e)
        {
            reformular_llegadas();
        }

        private void btn_reformular_atenciones_Click(object sender, EventArgs e)
        {
            reformular_atenciones();
        }

        private void reformular_llegadas()
        {
            txt_acum_llegadas_1.Text = nud_prob_llegadas_1.Value.ToString();
            txt_acum_llegadas_2.Text = (decimal.Parse(txt_acum_llegadas_1.Text) + nud_prob_llegadas_2.Value).ToString();
            txt_acum_llegadas_3.Text = (decimal.Parse(txt_acum_llegadas_2.Text) + nud_prob_llegadas_3.Value).ToString();
            txt_acum_llegadas_4.Text = (decimal.Parse(txt_acum_llegadas_3.Text) + nud_prob_llegadas_4.Value).ToString();
            txt_acum_llegadas_5.Text = (decimal.Parse(txt_acum_llegadas_4.Text) + nud_prob_llegadas_5.Value).ToString();

            txt_interv_llegadas_1.Text = "0 - " + (decimal.Parse(txt_acum_llegadas_1.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_llegadas_2.Text = txt_acum_llegadas_1.Text + " - " + (decimal.Parse(txt_acum_llegadas_2.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_llegadas_3.Text = txt_acum_llegadas_2.Text + " - " + (decimal.Parse(txt_acum_llegadas_3.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_llegadas_4.Text = txt_acum_llegadas_3.Text + " - " + (decimal.Parse(txt_acum_llegadas_4.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_llegadas_5.Text = txt_acum_llegadas_4.Text + " - " + (decimal.Parse(txt_acum_llegadas_5.Text) - decimal.Parse("0,01")).ToString();
        }

        private void reformular_atenciones()
        {
            txt_acum_atenciones_1.Text = nud_prob_atenciones_1.Value.ToString();
            txt_acum_atenciones_2.Text = (decimal.Parse(txt_acum_atenciones_1.Text) + nud_prob_atenciones_2.Value).ToString();
            txt_acum_atenciones_3.Text = (decimal.Parse(txt_acum_atenciones_2.Text) + nud_prob_atenciones_3.Value).ToString();
            txt_acum_atenciones_4.Text = (decimal.Parse(txt_acum_atenciones_3.Text) + nud_prob_atenciones_4.Value).ToString();
            txt_acum_atenciones_5.Text = (decimal.Parse(txt_acum_atenciones_4.Text) + nud_prob_atenciones_5.Value).ToString();
            txt_acum_atenciones_6.Text = (decimal.Parse(txt_acum_atenciones_5.Text) + nud_prob_atenciones_6.Value).ToString();

            txt_interv_atenciones_1.Text = "0 - " + (decimal.Parse(txt_acum_atenciones_1.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_atenciones_2.Text = txt_acum_atenciones_1.Text + " - " + (decimal.Parse(txt_acum_atenciones_2.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_atenciones_3.Text = txt_acum_atenciones_2.Text + " - " + (decimal.Parse(txt_acum_atenciones_3.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_atenciones_4.Text = txt_acum_atenciones_3.Text + " - " + (decimal.Parse(txt_acum_atenciones_4.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_atenciones_5.Text = txt_acum_atenciones_4.Text + " - " + (decimal.Parse(txt_acum_atenciones_5.Text) - decimal.Parse("0,01")).ToString();
            txt_interv_atenciones_6.Text = txt_acum_atenciones_5.Text + " - " + (decimal.Parse(txt_acum_atenciones_6.Text) - decimal.Parse("0,01")).ToString();
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Intermedio_Load(object sender, EventArgs e)
        {
            reformular_llegadas();
            reformular_atenciones();
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            if (decimal.Parse(txt_acum_llegadas_5.Text) != decimal.Parse("1") || decimal.Parse(txt_acum_atenciones_6.Text) != decimal.Parse("1"))
            {
                MessageBox.Show("La probabilidad acumulada debe ser 1", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double[] probabilidades_acum_llegadas = new double[5];
            double[] probabilidades_acum_atenciones = new double[6];

            int[] array_proximas_llegadas = new int[5];
            int[] array_proximas_atenciones = new int[6];

            probabilidades_acum_llegadas[0] = double.Parse(txt_acum_llegadas_1.Text);
            probabilidades_acum_llegadas[1] = double.Parse(txt_acum_llegadas_2.Text);
            probabilidades_acum_llegadas[2] = double.Parse(txt_acum_llegadas_3.Text);
            probabilidades_acum_llegadas[3] = double.Parse(txt_acum_llegadas_4.Text);
            probabilidades_acum_llegadas[4] = double.Parse(txt_acum_llegadas_5.Text);

            array_proximas_llegadas[0] = int.Parse(nud_llegadas_1.Value.ToString());
            array_proximas_llegadas[1] = int.Parse(nud_llegadas_2.Value.ToString());
            array_proximas_llegadas[2] = int.Parse(nud_llegadas_3.Value.ToString());
            array_proximas_llegadas[3] = int.Parse(nud_llegadas_4.Value.ToString());
            array_proximas_llegadas[4] = int.Parse(nud_llegadas_5.Value.ToString());

            probabilidades_acum_atenciones[0] = double.Parse(txt_acum_atenciones_1.Text);
            probabilidades_acum_atenciones[1] = double.Parse(txt_acum_atenciones_2.Text);
            probabilidades_acum_atenciones[2] = double.Parse(txt_acum_atenciones_3.Text);
            probabilidades_acum_atenciones[3] = double.Parse(txt_acum_atenciones_4.Text);
            probabilidades_acum_atenciones[4] = double.Parse(txt_acum_atenciones_5.Text);
            probabilidades_acum_atenciones[5] = double.Parse(txt_acum_atenciones_6.Text);

            array_proximas_atenciones[0] = int.Parse(nud_atenciones_1.Value.ToString());
            array_proximas_atenciones[1] = int.Parse(nud_atenciones_2.Value.ToString());
            array_proximas_atenciones[2] = int.Parse(nud_atenciones_3.Value.ToString());
            array_proximas_atenciones[3] = int.Parse(nud_atenciones_4.Value.ToString());
            array_proximas_atenciones[4] = int.Parse(nud_atenciones_5.Value.ToString());
            array_proximas_atenciones[5] = int.Parse(nud_atenciones_6.Value.ToString());

            Simulacion frm_simulacion = new Simulacion(tipo_iteracion, cantidad_iteraciones, cantidad_pacientes_diarios, cantidad_minutos_entre_pacientes, mostrar_pacientes, probabilidades_acum_llegadas, probabilidades_acum_atenciones, array_proximas_llegadas, array_proximas_atenciones);
            frm_simulacion.ShowDialog();

        }
    }
}
