using System.Windows.Forms;

namespace FINAL_SIMULACION
{
    partial class Simulacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_simular = new System.Windows.Forms.Button();
            this.btn_volver = new System.Windows.Forms.Button();
            this.txt_desde = new System.Windows.Forms.MaskedTextBox();
            this.lbl_iteracion_desde = new System.Windows.Forms.Label();
            this.dg_colas = new System.Windows.Forms.DataGridView();
            this.btn_cerrar_programa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dg_colas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F);
            this.label1.Location = new System.Drawing.Point(294, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 42);
            this.label1.TabIndex = 18;
            this.label1.Text = "Final SIM - Ejercicio 141";
            // 
            // btn_simular
            // 
            this.btn_simular.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_simular.Location = new System.Drawing.Point(813, 84);
            this.btn_simular.Name = "btn_simular";
            this.btn_simular.Size = new System.Drawing.Size(105, 34);
            this.btn_simular.TabIndex = 21;
            this.btn_simular.Text = "Simular";
            this.btn_simular.UseVisualStyleBackColor = true;
            this.btn_simular.Click += new System.EventHandler(this.btn_simular_Click);
            // 
            // btn_volver
            // 
            this.btn_volver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_volver.Location = new System.Drawing.Point(34, 84);
            this.btn_volver.Name = "btn_volver";
            this.btn_volver.Size = new System.Drawing.Size(105, 34);
            this.btn_volver.TabIndex = 27;
            this.btn_volver.Text = "Volver";
            this.btn_volver.UseVisualStyleBackColor = true;
            this.btn_volver.Click += new System.EventHandler(this.btn_volver_Click);
            // 
            // txt_desde
            // 
            this.txt_desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.txt_desde.Location = new System.Drawing.Point(678, 88);
            this.txt_desde.Mask = "99999";
            this.txt_desde.Name = "txt_desde";
            this.txt_desde.Size = new System.Drawing.Size(117, 29);
            this.txt_desde.TabIndex = 28;
            this.txt_desde.ValidatingType = typeof(int);
            // 
            // lbl_iteracion_desde
            // 
            this.lbl_iteracion_desde.BackColor = System.Drawing.Color.Transparent;
            this.lbl_iteracion_desde.Font = new System.Drawing.Font("SansSerif", 20.25F);
            this.lbl_iteracion_desde.Location = new System.Drawing.Point(189, 69);
            this.lbl_iteracion_desde.Name = "lbl_iteracion_desde";
            this.lbl_iteracion_desde.Size = new System.Drawing.Size(483, 58);
            this.lbl_iteracion_desde.TabIndex = 30;
            this.lbl_iteracion_desde.Text = "Ingrese desde que";
            this.lbl_iteracion_desde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dg_colas
            // 
            this.dg_colas.AllowUserToAddRows = false;
            this.dg_colas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_colas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_colas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_colas.Location = new System.Drawing.Point(34, 130);
            this.dg_colas.Name = "dg_colas";
            this.dg_colas.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_colas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dg_colas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_colas.RowTemplate.Height = 25;
            this.dg_colas.Size = new System.Drawing.Size(883, 491);
            this.dg_colas.TabIndex = 31;
            // 
            // btn_cerrar_programa
            // 
            this.btn_cerrar_programa.BackColor = System.Drawing.Color.Transparent;
            this.btn_cerrar_programa.BackgroundImage = global::FINAL_SIMULACION.Properties.Resources.cerrar;
            this.btn_cerrar_programa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_cerrar_programa.FlatAppearance.BorderSize = 0;
            this.btn_cerrar_programa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar_programa.Location = new System.Drawing.Point(919, 11);
            this.btn_cerrar_programa.Name = "btn_cerrar_programa";
            this.btn_cerrar_programa.Size = new System.Drawing.Size(43, 43);
            this.btn_cerrar_programa.TabIndex = 16;
            this.btn_cerrar_programa.UseVisualStyleBackColor = false;
            this.btn_cerrar_programa.Click += new System.EventHandler(this.btn_cerrar_programa_Click);
            // 
            // Simulacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(973, 730);
            this.Controls.Add(this.dg_colas);
            this.Controls.Add(this.lbl_iteracion_desde);
            this.Controls.Add(this.txt_desde);
            this.Controls.Add(this.btn_volver);
            this.Controls.Add(this.btn_cerrar_programa);
            this.Controls.Add(this.btn_simular);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Simulacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Simulacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_colas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_cerrar_programa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_simular;
        private Button btn_volver;
        private MaskedTextBox txt_desde;
        private Label lbl_iteracion_desde;
        private DataGridView dg_colas;
    }
}