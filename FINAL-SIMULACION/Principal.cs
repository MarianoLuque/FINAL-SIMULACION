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
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btn_cerrar_programa_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            if (!rb_eventos.Checked && !rb_minutos.Checked && !rb_jornadas.Checked)
            {
                MessageBox.Show("Seleccione un parámetro para la cantidad de eventos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (rb_minutos.Checked && (txt_cantidad_minutos.Text == "" || int.Parse(txt_cantidad_minutos.Text) < 2000))
            {
                MessageBox.Show("Ingrese la cantidad de minutos a simular (mayor o igual a 2000)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (rb_eventos.Checked && (txt_cantidad_eventos.Text == "" || int.Parse(txt_cantidad_eventos.Text) < 400))
            {
                MessageBox.Show("Ingrese la cantidad de eventos a simular (mayor o igual a 400)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (rb_jornadas.Checked && (txt_cantidad_jornadas.Text == "" || int.Parse(txt_cantidad_jornadas.Text) < 20))
            {
                MessageBox.Show("Ingrese la cantidad de jornadas a simular (mayor o igual a 20)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txt_cantidad_pacientes.Text == "" || txt_cantidad_minutos_entre_pacientes.Text == "")
            {
                MessageBox.Show("Ingrese la cantidad de pacientes por día y minutos entre pacientes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string tipo_iteracion = "";
            int cantidad_iteraciones = 0;
            if (rb_minutos.Checked)
            {
                tipo_iteracion = "minutos";
                cantidad_iteraciones = int.Parse(txt_cantidad_minutos.Text);
            }
            if (rb_eventos.Checked)
            {
                tipo_iteracion = "eventos";
                cantidad_iteraciones = int.Parse(txt_cantidad_eventos.Text);
            }
            if (rb_jornadas.Checked)
            {
                tipo_iteracion = "jornadas";
                cantidad_iteraciones = int.Parse(txt_cantidad_jornadas.Text);
            }
            Intermedio frm_intermedio = new Intermedio(tipo_iteracion, cantidad_iteraciones, int.Parse(txt_cantidad_pacientes.Text), int.Parse(txt_cantidad_minutos_entre_pacientes.Text), cb_mostrar_pacientes.Checked);
            frm_intermedio.ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            txt_cantidad_pacientes.Text = "16";
            txt_cantidad_minutos_entre_pacientes.Text = "30";
        }
    }
}
