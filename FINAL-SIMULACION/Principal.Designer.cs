using System.Windows.Forms;

namespace FINAL_SIMULACION
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_cantidad_minutos = new System.Windows.Forms.MaskedTextBox();
            this.btn_cerrar_programa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_simular = new System.Windows.Forms.Button();
            this.rb_minutos = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_cantidad_jornadas = new System.Windows.Forms.MaskedTextBox();
            this.rb_jornadas = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_cantidad_eventos = new System.Windows.Forms.MaskedTextBox();
            this.rb_eventos = new System.Windows.Forms.RadioButton();
            this.cb_mostrar_pacientes = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_cantidad_minutos_entre_pacientes = new System.Windows.Forms.MaskedTextBox();
            this.txt_cantidad_pacientes = new System.Windows.Forms.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_cantidad_minutos
            // 
            this.txt_cantidad_minutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cantidad_minutos.Location = new System.Drawing.Point(501, 91);
            this.txt_cantidad_minutos.Mask = "9999999";
            this.txt_cantidad_minutos.Name = "txt_cantidad_minutos";
            this.txt_cantidad_minutos.Size = new System.Drawing.Size(169, 29);
            this.txt_cantidad_minutos.TabIndex = 17;
            this.txt_cantidad_minutos.ValidatingType = typeof(int);
            // 
            // btn_cerrar_programa
            // 
            this.btn_cerrar_programa.BackColor = System.Drawing.Color.Transparent;
            this.btn_cerrar_programa.BackgroundImage = global::FINAL_SIMULACION.Properties.Resources.cerrar;
            this.btn_cerrar_programa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cerrar_programa.FlatAppearance.BorderSize = 0;
            this.btn_cerrar_programa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar_programa.Location = new System.Drawing.Point(736, 10);
            this.btn_cerrar_programa.Name = "btn_cerrar_programa";
            this.btn_cerrar_programa.Size = new System.Drawing.Size(43, 43);
            this.btn_cerrar_programa.TabIndex = 16;
            this.btn_cerrar_programa.UseVisualStyleBackColor = false;
            this.btn_cerrar_programa.Click += new System.EventHandler(this.btn_cerrar_programa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label2.Location = new System.Drawing.Point(5, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(443, 29);
            this.label2.TabIndex = 19;
            this.label2.Text = "Ingrese la cantidad de minutos a simular";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F);
            this.label1.Location = new System.Drawing.Point(212, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 42);
            this.label1.TabIndex = 18;
            this.label1.Text = "Final SIM - Ejercicio 141";
            // 
            // btn_simular
            // 
            this.btn_simular.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_simular.Location = new System.Drawing.Point(621, 447);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(105, 34);
            this.btn_simular.TabIndex = 21;
            this.btn_simular.Text = "Continuar";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // rb_minutos
            // 
            this.rb_minutos.AutoSize = true;
            this.rb_minutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.rb_minutos.Location = new System.Drawing.Point(9, 60);
            this.rb_minutos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_minutos.Name = "rb_minutos";
            this.rb_minutos.Size = new System.Drawing.Size(320, 29);
            this.rb_minutos.TabIndex = 22;
            this.rb_minutos.TabStop = true;
            this.rb_minutos.Text = "Cantidad de minutos a simular";
            this.rb_minutos.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_cantidad_jornadas);
            this.groupBox2.Controls.Add(this.rb_jornadas);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txt_cantidad_eventos);
            this.groupBox2.Controls.Add(this.rb_eventos);
            this.groupBox2.Controls.Add(this.txt_cantidad_minutos);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rb_minutos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.groupBox2.Location = new System.Drawing.Point(48, 58);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(678, 257);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parámetros para la cantidad de eventos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label3.Location = new System.Drawing.Point(5, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(406, 25);
            this.label3.TabIndex = 28;
            this.label3.Text = "Ingrese la cantidad de jornadas a simular";
            this.label3.Visible = false;
            // 
            // txt_cantidad_jornadas
            // 
            this.txt_cantidad_jornadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cantidad_jornadas.Location = new System.Drawing.Point(501, 214);
            this.txt_cantidad_jornadas.Mask = "99999";
            this.txt_cantidad_jornadas.Name = "txt_cantidad_jornadas";
            this.txt_cantidad_jornadas.Size = new System.Drawing.Size(169, 29);
            this.txt_cantidad_jornadas.TabIndex = 27;
            this.txt_cantidad_jornadas.ValidatingType = typeof(int);
            this.txt_cantidad_jornadas.Visible = false;
            // 
            // rb_jornadas
            // 
            this.rb_jornadas.AutoSize = true;
            this.rb_jornadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.rb_jornadas.Location = new System.Drawing.Point(178, 213);
            this.rb_jornadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_jornadas.Name = "rb_jornadas";
            this.rb_jornadas.Size = new System.Drawing.Size(328, 29);
            this.rb_jornadas.TabIndex = 26;
            this.rb_jornadas.TabStop = true;
            this.rb_jornadas.Text = "Cantidad de jornadas a simular";
            this.rb_jornadas.UseVisualStyleBackColor = true;
            this.rb_jornadas.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.label14.Location = new System.Drawing.Point(5, 169);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(399, 25);
            this.label14.TabIndex = 25;
            this.label14.Text = "Ingrese la cantidad de eventos a simular";
            // 
            // txt_cantidad_eventos
            // 
            this.txt_cantidad_eventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cantidad_eventos.Location = new System.Drawing.Point(501, 166);
            this.txt_cantidad_eventos.Mask = "9999999";
            this.txt_cantidad_eventos.Name = "txt_cantidad_eventos";
            this.txt_cantidad_eventos.Size = new System.Drawing.Size(169, 29);
            this.txt_cantidad_eventos.TabIndex = 24;
            this.txt_cantidad_eventos.ValidatingType = typeof(int);
            // 
            // rb_eventos
            // 
            this.rb_eventos.AutoSize = true;
            this.rb_eventos.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.rb_eventos.Location = new System.Drawing.Point(9, 138);
            this.rb_eventos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rb_eventos.Name = "rb_eventos";
            this.rb_eventos.Size = new System.Drawing.Size(321, 29);
            this.rb_eventos.TabIndex = 23;
            this.rb_eventos.TabStop = true;
            this.rb_eventos.Text = "Cantidad de eventos a simular";
            this.rb_eventos.UseVisualStyleBackColor = true;
            // 
            // cb_mostrar_pacientes
            // 
            this.cb_mostrar_pacientes.AutoSize = true;
            this.cb_mostrar_pacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.cb_mostrar_pacientes.Location = new System.Drawing.Point(349, 451);
            this.cb_mostrar_pacientes.Name = "cb_mostrar_pacientes";
            this.cb_mostrar_pacientes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cb_mostrar_pacientes.Size = new System.Drawing.Size(257, 28);
            this.cb_mostrar_pacientes.TabIndex = 24;
            this.cb_mostrar_pacientes.Text = "Mostrar todos los pacientes";
            this.cb_mostrar_pacientes.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_cantidad_minutos_entre_pacientes);
            this.groupBox3.Controls.Add(this.txt_cantidad_pacientes);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.groupBox3.Location = new System.Drawing.Point(47, 321);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(679, 111);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Parámetros de pacientes";
            // 
            // txt_cantidad_minutos_entre_pacientes
            // 
            this.txt_cantidad_minutos_entre_pacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cantidad_minutos_entre_pacientes.Location = new System.Drawing.Point(287, 68);
            this.txt_cantidad_minutos_entre_pacientes.Mask = "99";
            this.txt_cantidad_minutos_entre_pacientes.Name = "txt_cantidad_minutos_entre_pacientes";
            this.txt_cantidad_minutos_entre_pacientes.Size = new System.Drawing.Size(85, 29);
            this.txt_cantidad_minutos_entre_pacientes.TabIndex = 22;
            this.txt_cantidad_minutos_entre_pacientes.ValidatingType = typeof(int);
            // 
            // txt_cantidad_pacientes
            // 
            this.txt_cantidad_pacientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_cantidad_pacientes.Location = new System.Drawing.Point(287, 37);
            this.txt_cantidad_pacientes.Mask = "99";
            this.txt_cantidad_pacientes.Name = "txt_cantidad_pacientes";
            this.txt_cantidad_pacientes.Size = new System.Drawing.Size(85, 29);
            this.txt_cantidad_pacientes.TabIndex = 22;
            this.txt_cantidad_pacientes.ValidatingType = typeof(int);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label25.Location = new System.Drawing.Point(9, 71);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(316, 24);
            this.label25.TabIndex = 19;
            this.label25.Text = "Cantidad de minutos entre pacientes";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label26.Location = new System.Drawing.Point(9, 40);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(257, 24);
            this.label26.TabIndex = 19;
            this.label26.Text = "Cantidad de pacientes diarios";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(795, 520);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cb_mostrar_pacientes);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_cerrar_programa);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox txt_cantidad_minutos;
        private System.Windows.Forms.Button btn_cerrar_programa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_simular;
        private System.Windows.Forms.RadioButton rb_minutos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txt_cantidad_eventos;
        private System.Windows.Forms.RadioButton rb_eventos;
        private System.Windows.Forms.CheckBox cb_mostrar_pacientes;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.MaskedTextBox txt_cantidad_minutos_entre_pacientes;
        private System.Windows.Forms.MaskedTextBox txt_cantidad_pacientes;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private Label label3;
        private MaskedTextBox txt_cantidad_jornadas;
        private RadioButton rb_jornadas;
    }
}

