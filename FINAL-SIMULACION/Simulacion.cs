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
    public partial class Simulacion : Form
    {
        #region Variables principales
        string tipo_iteracion;
        int cantidad_iteraciones;
        int cantidad_pacientes_diarios;
        int cantidad_minutos_entre_pacientes;
        bool mostrar_pacientes;
        double[] probabilidades_acum_llegadas;
        double[] probabilidades_acum_atenciones;
        int[] array_proximas_llegadas;
        int[] array_proximas_atenciones;
        #endregion

        #region Randoms
        Random objeto_rnd_llegadas;
        Random objeto_rnd_atencion;
        Random objeto_semilla;
        #endregion

        int jornada;
        int nro_evento;
        int iteracion_desde;
        int cantidad_iteraciones_actual = 0;
        bool flag_tabla_cargada = false;
        bool flag_primera_vuelta;
        double reloj = 0;
        int cantidad_a_mostrar;
        string Evento_lanzado;
        int pacientes_atendidos_en_jornada;

        //Metricas
        double acumulador_tiempo_ocioso_en_jornada;
        double acumulador_tiempo_ocioso_total;
        double acumulador_tiempo_consultorio_en_jornada;
        double acumulador_tiempo_consultorio_total;

        //llegadas
        double rnd_llegadas;
        double tiempo_entre_llegadas = 0.0;
        double tiempo_proxima_llegada = 0.0;

        //atenciones
        double rnd_atencion;
        double tiempo_atencion = 0.0;

        //clientes
        List<cliente> cola_clientes;
        List<cliente> clientes_a_mostrar;
        int nro_cliente;
        int nro_cliente_desde_que_se_muestra;
        bool bandera_nro_cliente;

        servidor server;
        DataTable tabla_iteraciones = new DataTable();
        public Simulacion(string tipo_iteracion, int cantidad_iteraciones, int cantidad_pacientes_diarios, int cantidad_minutos_entre_pacientes, bool mostrar_pacientes, double[] probabilidades_acum_llegadas, double[] probabilidades_acum_atenciones, int[] array_proximas_llegadas, int[] array_proximas_atenciones)
        {
            this.tipo_iteracion = tipo_iteracion;
            this.cantidad_iteraciones = cantidad_iteraciones;
            this.cantidad_pacientes_diarios = cantidad_pacientes_diarios;
            this.cantidad_minutos_entre_pacientes = cantidad_minutos_entre_pacientes;
            this.mostrar_pacientes = mostrar_pacientes;
            this.probabilidades_acum_llegadas = probabilidades_acum_llegadas;
            this.probabilidades_acum_atenciones = probabilidades_acum_atenciones;
            this.array_proximas_llegadas = array_proximas_llegadas;
            this.array_proximas_atenciones = array_proximas_atenciones;
            InitializeComponent();
        }

        private void btn_cerrar_programa_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Simulacion_Load(object sender, EventArgs e)
        {
            switch (tipo_iteracion)
            {
                case "minutos":
                    lbl_iteracion_desde.Text += " minuto simular";
                    break;
                case "eventos":
                    lbl_iteracion_desde.Text += " evento simular";
                    break;
                case "jornadas":
                    lbl_iteracion_desde.Text += " jornada simular";
                    break;
                default:
                    break;
            }
        }

        private void agregar_cliente()
        {
            string estado_cliente_nro = "Estado paciente " + nro_cliente.ToString();
            string hora_llegada_cliente_nro = "Hora llegada paciente " + nro_cliente.ToString();
            DataColumn columna_estado_cliente = new DataColumn(estado_cliente_nro);
            DataColumn columna_hora_llegada_cliente = new DataColumn(hora_llegada_cliente_nro);
            tabla_iteraciones.Columns.Add(columna_estado_cliente);
            tabla_iteraciones.Columns.Add(columna_hora_llegada_cliente);
            if (nro_cliente_desde_que_se_muestra == 0 && bandera_nro_cliente)
            {
                nro_cliente_desde_que_se_muestra = nro_cliente;
                bandera_nro_cliente = false;
            }
        }

        private void btn_simular_Click(object sender, EventArgs e)
        {
            objeto_semilla = new Random();
            objeto_rnd_llegadas = new Random(objeto_semilla.Next());
            objeto_rnd_atencion = new Random(objeto_semilla.Next());

            //pregunto si el programa ya se ejecuto
            if (flag_tabla_cargada)
            {
                //desligo la tabla del data source
                dg_colas.DataSource = null;
                //limpiar las filas
                tabla_iteraciones.Rows.Clear();
                for (int i = nro_cliente_desde_que_se_muestra; i < (clientes_a_mostrar.Count + nro_cliente_desde_que_se_muestra); i++)
                {
                    tabla_iteraciones.Columns.Remove("Estado paciente " + i.ToString());
                    tabla_iteraciones.Columns.Remove("Hora llegada paciente " + i.ToString());
                }

            }
            else
            {
                //si no se ejecuto cargo las columnas de la tabla
                cargarTabla();
                flag_tabla_cargada = true;
            }

            volverACero();

            server = new servidor();

            if (tipo_iteracion == "minutos")
            {
                if (!int.TryParse(txt_desde.Text, out iteracion_desde) || iteracion_desde >= (cantidad_iteraciones))
                {
                    MessageBox.Show("Ingrese desde que minuto se debe mostrar (valor mayor a 0 y menor a " + (cantidad_iteraciones).ToString() + ")", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
                while (reloj < cantidad_iteraciones)
                {
                    siguiente_secuencia();

                    if (reloj >= iteracion_desde && cantidad_a_mostrar < 400)
                    {
                        cargar_datos_tabla(cantidad_a_mostrar);
                        cantidad_a_mostrar += 1;
                    }

                    if (cantidad_a_mostrar >= 400 && reloj >= cantidad_iteraciones)
                    {
                        Evento_lanzado = "Fin de simulación";
                        cargar_datos_tabla(400);
                    }
                }
            }

            if (tipo_iteracion == "eventos")
            {
                if (!int.TryParse(txt_desde.Text, out iteracion_desde) || iteracion_desde > (cantidad_iteraciones - 400))
                {
                    MessageBox.Show("Ingrese desde que evento se debe mostrar (valor mayor a 0 y menor a " + (cantidad_iteraciones - 400).ToString() + ")", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                while (cantidad_iteraciones_actual < cantidad_iteraciones)
                {
                    siguiente_secuencia();

                    if (cantidad_iteraciones_actual >= iteracion_desde && cantidad_iteraciones_actual < iteracion_desde + 400)
                    {
                        cargar_datos_tabla(cantidad_iteraciones_actual - iteracion_desde);
                    }
                    cantidad_iteraciones_actual += 1;

                    if (cantidad_iteraciones_actual == cantidad_iteraciones && cantidad_iteraciones_actual != (iteracion_desde + 400))
                    {
                        Evento_lanzado = "Fin de simulación";
                        cargar_datos_tabla(400);
                    }
                }
            }

            if (tipo_iteracion == "jornadas")
            {
                if (!int.TryParse(txt_desde.Text, out iteracion_desde) || iteracion_desde > cantidad_iteraciones)
                {
                    MessageBox.Show("Ingrese desde que jornada se debe mostrar (valor mayor a 0 y menor a " + (cantidad_iteraciones).ToString() + ")", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                while (jornada < cantidad_iteraciones)
                {
                    siguiente_secuencia();

                    if (jornada >= iteracion_desde && jornada < cantidad_iteraciones)
                    {
                        cargar_datos_tabla(jornada - iteracion_desde);
                    }
                    cantidad_iteraciones_actual += 1;

                    if (jornada == cantidad_iteraciones)
                    {
                        Evento_lanzado = "Fin de simulación";
                        cargar_datos_tabla(cantidad_iteraciones);
                    }
                }
            }

            dg_colas.DataSource = tabla_iteraciones;
            ModificarColumnas();
        }

        private void ModificarColumnas()
        {

            //Evento, reloj y jornada
            dg_colas.Columns["Nro Evento"].Width = 50;
            dg_colas.Columns["Evento"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
            dg_colas.Columns["Evento"].Width = 120;
            dg_colas.Columns["Reloj (min)"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
            dg_colas.Columns["Reloj (min)"].Width = 50;
            dg_colas.Columns["Nro jornada"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
            dg_colas.Columns["Nro jornada"].Width = 50;

            //Llegadas
            dg_colas.Columns["RND llegada paciente"].DefaultCellStyle.BackColor = Color.DarkGray;
            dg_colas.Columns["RND llegada paciente"].Width = 60;
            dg_colas.Columns["Tiempo entre llegadas"].DefaultCellStyle.BackColor = Color.DarkGray;
            dg_colas.Columns["Tiempo entre llegadas"].Width = 60;
            dg_colas.Columns["Proxima llegada"].DefaultCellStyle.BackColor = Color.DarkGray;
            dg_colas.Columns["Proxima llegada"].Width = 60;

            //Atenciones
            dg_colas.Columns["RND atencion"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
            dg_colas.Columns["RND atencion"].Width = 60;
            dg_colas.Columns["Tiempo atencion"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
            dg_colas.Columns["Tiempo atencion"].Width = 60;
            dg_colas.Columns["Fin atencion"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
            dg_colas.Columns["Fin atencion"].Width = 60;

            //Consultorio
            dg_colas.Columns["Estado consultorio"].DefaultCellStyle.BackColor = Color.DarkGray;
            dg_colas.Columns["Cola consultorio"].DefaultCellStyle.BackColor = Color.DarkGray;

            //Tiempo ocioso
            dg_colas.Columns["Tiempo ocioso acumulado en la jornada"].DefaultCellStyle.BackColor = Color.LightSeaGreen;
            dg_colas.Columns["Tiempo ocioso acumulado total"].DefaultCellStyle.BackColor = Color.LightSeaGreen;

            //Tiempo en consultorio
            dg_colas.Columns["Tiempo en consultorio acumulado en la jornada"].DefaultCellStyle.BackColor = Color.DarkGray;
            dg_colas.Columns["Tiempo en consultorio acumulado total"].DefaultCellStyle.BackColor = Color.DarkGray;

            dg_colas.Refresh();
        }

        private void cargarTabla()
        {

            DataColumn nro_evento = new DataColumn("Nro Evento");
            tabla_iteraciones.Columns.Add(nro_evento);
            DataColumn evento = new DataColumn("Evento");
            tabla_iteraciones.Columns.Add(evento);

            //asigno las columnas a la tabla
            DataColumn columna_reloj = new DataColumn("Reloj (min)");
            tabla_iteraciones.Columns.Add(columna_reloj);

            //Jornada
            DataColumn columna_jornada = new DataColumn("Nro jornada");
            tabla_iteraciones.Columns.Add(columna_jornada);

            //Llegada cliente
            DataColumn columna_rnd_llegada = new DataColumn("RND llegada paciente");
            tabla_iteraciones.Columns.Add(columna_rnd_llegada);
            DataColumn columna_tiempo_entre_llegadas = new DataColumn("Tiempo entre llegadas");
            tabla_iteraciones.Columns.Add(columna_tiempo_entre_llegadas);
            DataColumn columna_proxima_llegada = new DataColumn("Proxima llegada");
            tabla_iteraciones.Columns.Add(columna_proxima_llegada);


            //Atencion caseta
            DataColumn columna_rnd_atencion = new DataColumn("RND atencion");
            tabla_iteraciones.Columns.Add(columna_rnd_atencion);
            DataColumn columna_tiempo_atencion = new DataColumn("Tiempo atencion");
            tabla_iteraciones.Columns.Add(columna_tiempo_atencion);
            DataColumn columna_fin_atencion = new DataColumn("Fin atencion");
            tabla_iteraciones.Columns.Add(columna_fin_atencion);

            //Medico
            DataColumn columna_estado = new DataColumn("Estado consultorio");
            tabla_iteraciones.Columns.Add(columna_estado);
            DataColumn columna_cola = new DataColumn("Cola consultorio");
            tabla_iteraciones.Columns.Add(columna_cola);

            //Tiempo ocioso
            DataColumn columna_acumulador_ocioso_en_jornada = new DataColumn("Tiempo ocioso acumulado en la jornada");
            tabla_iteraciones.Columns.Add(columna_acumulador_ocioso_en_jornada);
            DataColumn columna_acumulador_ocioso_total = new DataColumn("Tiempo ocioso acumulado total");
            tabla_iteraciones.Columns.Add(columna_acumulador_ocioso_total);

            //Tiempo en consultorio
            DataColumn columna_acumulador_consultorio_en_jornada = new DataColumn("Tiempo en consultorio acumulado en la jornada");
            tabla_iteraciones.Columns.Add(columna_acumulador_consultorio_en_jornada);
            DataColumn columna_acumulador_consultorio_total = new DataColumn("Tiempo en consultorio acumulado total");
            tabla_iteraciones.Columns.Add(columna_acumulador_consultorio_total);
        }

        private void volverACero()
        {
            //clientes
            clientes_a_mostrar = new List<cliente>();
            nro_cliente_desde_que_se_muestra = 0;
            nro_cliente = 0;
            bandera_nro_cliente = true;
            cola_clientes = new List<cliente>();

            acumulador_tiempo_consultorio_total = 0;
            acumulador_tiempo_ocioso_total = 0;

            reloj = 0;
            nro_evento = 0;

            flag_primera_vuelta = false;

            cantidad_iteraciones_actual = 0;
            cantidad_a_mostrar = 0;
        }

        private void siguiente_secuencia()
        {
            //En la primera vuelta solo va a calcular la proxima llegada
            nro_evento += 1;
            if (!flag_primera_vuelta)
            {
                flag_primera_vuelta = true;
                Evento_lanzado = "Inicio de jornada";
                pacientes_atendidos_en_jornada = 0;
                jornada = 1;

                server.SetInicioOcio(reloj);
                acumulador_tiempo_ocioso_en_jornada = 0;
                acumulador_tiempo_consultorio_en_jornada = 0;

                cola_clientes = new List<cliente>();

                calcularProximaLlegada();
            }
            else
            {
                /*switch (tipo_iteracion)
                {
                    case "minutos":
                        if (reloj > cantidad_iteraciones)
                        {
                            reloj = cantidad_iteraciones;
                            Evento_lanzado = "Fin de simulación";
                            return;
                        }
                        break;
                    case "eventos":
                        if (cantidad_iteraciones_actual >= cantidad_iteraciones)
                        {
                            Evento_lanzado = "Fin de simulación";
                            return;
                        }
                        break;
                    case "jornadas":
                        if (cantidad_iteraciones_actual >= cantidad_iteraciones)
                        {
                            Evento_lanzado = "Fin de simulación";
                            return;
                        }
                        break;
                }*/

                double fin_atencion_server = server.GetFinAtencion();
                if (pacientes_atendidos_en_jornada < cantidad_pacientes_diarios)
                {
                    if (fin_atencion_server == 0.01 || tiempo_proxima_llegada <= fin_atencion_server)
                    {
                        reloj = tiempo_proxima_llegada;
                        eventoLlegadaCliente();
                    }
                    else
                    {
                        reloj = fin_atencion_server;
                        eventoFinAtencion();
                    }
                }
                else
                {
                    if (cola_clientes.Count != 0 || server.GetCliente() != null)
                    {
                        reloj = fin_atencion_server;
                        eventoFinAtencion();
                    }
                    else
                    {
                        eventoInicioDeJornada();
                    }

                }


            }
        }

        private void eventoInicioDeJornada()
        {
            Evento_lanzado = "Inicio de jornada";
            pacientes_atendidos_en_jornada = 0;
            jornada += 1;

            server.SetFinAtencion(0.01);
            server.SetInicioOcio(reloj);
            acumulador_tiempo_ocioso_en_jornada = 0;
            acumulador_tiempo_consultorio_en_jornada = 0;

            calcularProximaLlegada();
        }

        private void eventoLlegadaCliente()
        {
            Evento_lanzado = "Llegada Paciente";
            cliente Nuevo_Cliente = null;
            pacientes_atendidos_en_jornada += 1;

            if (server.GetEstado() == servidor.Estados.libre)
            {
                Nuevo_Cliente = new cliente(reloj, cliente.Estados.SIENDO_ATENDIDO);
                server.SetCliente(Nuevo_Cliente);
                server.SetEstado(servidor.Estados.ocupado);

                double tiempo_ocioso = (reloj - server.GetInicioOcio());
                acumulador_tiempo_ocioso_en_jornada += tiempo_ocioso;
                acumulador_tiempo_ocioso_total += tiempo_ocioso;

                calcularFinAtencion();
                server.SetInicioAtencion(reloj);
            }
            else
            {
                Nuevo_Cliente = new cliente(reloj, cliente.Estados.ESPERANDO_ATENCION);
                cola_clientes.Add(Nuevo_Cliente);
            }

            if (mostrar_pacientes)
            {
                if (tipo_iteracion == "eventos")
                {
                    if (cantidad_iteraciones_actual >= iteracion_desde && cantidad_iteraciones_actual < iteracion_desde + 400)
                    {
                        clientes_a_mostrar.Add(Nuevo_Cliente);
                        agregar_cliente();
                    }
                }
                else if (tipo_iteracion == "minutos")
                {
                    if (reloj >= iteracion_desde && cantidad_a_mostrar < 400)
                    {
                        clientes_a_mostrar.Add(Nuevo_Cliente);
                        agregar_cliente();
                    }
                }
                else
                {
                    if (cantidad_iteraciones_actual >= iteracion_desde && cantidad_iteraciones_actual < iteracion_desde + 400)
                    {
                        clientes_a_mostrar.Add(Nuevo_Cliente);
                        agregar_cliente();
                    }
                }
                nro_cliente += 1;
            }
            if (pacientes_atendidos_en_jornada < (cantidad_pacientes_diarios))
            {
                calcularProximaLlegada();
            }
        }

        private void eventoFinAtencion()
        {
            Evento_lanzado = "Fin Atencion";
            if (cola_clientes.Count == 0)
            {
                server.SetEstado(servidor.Estados.libre);

                double tiempo_en_consultorio = reloj - server.GetInicioAtencion();
                acumulador_tiempo_consultorio_en_jornada += tiempo_en_consultorio;
                acumulador_tiempo_consultorio_total += tiempo_en_consultorio;
                server.SetInicioOcio(reloj);

                rnd_atencion = 0;
                tiempo_atencion = 0;
                server.SetFinAtencion(0.01);
                server.GetCliente().SetEstado(cliente.Estados.FUERA_DEL_SISTEMA);
                server.SetCliente(null);
            }
            else
            {
                server.GetCliente().SetEstado(cliente.Estados.FUERA_DEL_SISTEMA);

                double tiempo_en_consultorio = reloj - server.GetInicioAtencion();
                acumulador_tiempo_consultorio_en_jornada += tiempo_en_consultorio;
                acumulador_tiempo_consultorio_total += tiempo_en_consultorio;
                server.SetInicioAtencion(reloj);

                server.SetCliente(cola_clientes.ElementAt(0));
                server.GetCliente().SetEstado(cliente.Estados.SIENDO_ATENDIDO);
                cola_clientes.RemoveAt(0);
                calcularFinAtencion();
            }
        }

        private void calcularProximaLlegada()
        {
            rnd_llegadas = (Math.Truncate(objeto_rnd_llegadas.NextDouble() * 100)) / 100;

            for (int i = 0; i < probabilidades_acum_llegadas.Length; i++)
            {
                if (rnd_llegadas < probabilidades_acum_llegadas[0])
                {
                    tiempo_entre_llegadas = array_proximas_llegadas[0];
                    break;
                }
                if (rnd_llegadas >= probabilidades_acum_llegadas[i] && rnd_llegadas < probabilidades_acum_llegadas[i + 1])
                {
                    tiempo_entre_llegadas = array_proximas_llegadas[i + 1];
                    break;
                }
            }
            tiempo_proxima_llegada = Math.Truncate((reloj + tiempo_entre_llegadas) * 100) / 100;
        }

        private void calcularFinAtencion()
        {
            rnd_atencion = (Math.Truncate(objeto_rnd_atencion.NextDouble() * 100)) / 100;

            for (int i = 0; i < probabilidades_acum_atenciones.Length; i++)
            {
                if (rnd_atencion < probabilidades_acum_atenciones[0])
                {
                    tiempo_atencion = array_proximas_atenciones[0];
                    break;
                }
                if (rnd_atencion >= probabilidades_acum_atenciones[i] && rnd_atencion < probabilidades_acum_atenciones[i + 1])
                {
                    tiempo_atencion = array_proximas_atenciones[i + 1];
                    break;
                }
            }
            server.SetFinAtencion((Math.Truncate((reloj + tiempo_atencion) * 100)) / 100);

        }

        private void cargar_datos_tabla(int cantidad_iteraciones)
        {
            tabla_iteraciones.Rows.Add();
            //Cargar columnas y mostrarlas
            tabla_iteraciones.Rows[cantidad_iteraciones]["Nro Evento"] = nro_evento;
            tabla_iteraciones.Rows[cantidad_iteraciones]["Evento"] = Evento_lanzado;
            tabla_iteraciones.Rows[cantidad_iteraciones]["Reloj (min)"] = reloj;
            tabla_iteraciones.Rows[cantidad_iteraciones]["Nro jornada"] = jornada;

            if (cantidad_iteraciones != 0 && (pacientes_atendidos_en_jornada < cantidad_pacientes_diarios))
            {
                if (tiempo_proxima_llegada.ToString() == tabla_iteraciones.Rows[cantidad_iteraciones - 1]["Proxima llegada"].ToString())
                {
                    tabla_iteraciones.Rows[cantidad_iteraciones]["RND llegada paciente"] = "";
                    tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo entre llegadas"] = "";
                }
                else
                {
                    tabla_iteraciones.Rows[cantidad_iteraciones]["RND llegada paciente"] = rnd_llegadas.ToString() == "0" ? "" : rnd_llegadas.ToString();
                    tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo entre llegadas"] = tiempo_entre_llegadas.ToString() == "0" ? "" : tiempo_entre_llegadas.ToString();
                }
            }
            else
            {
                tabla_iteraciones.Rows[cantidad_iteraciones]["RND llegada paciente"] = "";
                tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo entre llegadas"] = "";
            }
            if (cantidad_iteraciones == 0)
            {
                tabla_iteraciones.Rows[cantidad_iteraciones]["RND llegada paciente"] = rnd_llegadas.ToString() == "0" ? "" : rnd_llegadas.ToString();
                tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo entre llegadas"] = tiempo_entre_llegadas.ToString() == "0" ? "" : tiempo_entre_llegadas.ToString();
            }
            if (!(pacientes_atendidos_en_jornada < cantidad_pacientes_diarios))
            {
                tabla_iteraciones.Rows[cantidad_iteraciones]["Proxima llegada"] = "";
            }
            else
            {
                tabla_iteraciones.Rows[cantidad_iteraciones]["Proxima llegada"] = tiempo_proxima_llegada.ToString() == "0" ? "" : tiempo_proxima_llegada.ToString();
            }


            if (cantidad_iteraciones != 0)
            {
                if (server.GetFinAtencion().ToString() == tabla_iteraciones.Rows[cantidad_iteraciones - 1]["Fin atencion"].ToString())
                {
                    tabla_iteraciones.Rows[cantidad_iteraciones]["RND atencion"] = "";
                    tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo atencion"] = "";
                }
                else
                {
                    tabla_iteraciones.Rows[cantidad_iteraciones]["RND atencion"] = rnd_atencion.ToString() == "0" ? "" : rnd_atencion.ToString();
                    tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo atencion"] = tiempo_atencion.ToString() == "0" ? "" : tiempo_atencion.ToString();
                }
            }
            //if((cantidad_iteraciones != 0 || nro_evento != 1) && Evento_lanzado != "Inicio de jornada")
            if (cantidad_iteraciones != 0)
            {
                tabla_iteraciones.Rows[cantidad_iteraciones]["Fin atencion"] = server.GetFinAtencion().ToString() == "0,01" ? "" : server.GetFinAtencion().ToString();
            }
            else
            {
                tabla_iteraciones.Rows[cantidad_iteraciones]["Fin atencion"] = "";
            }


            tabla_iteraciones.Rows[cantidad_iteraciones]["Estado consultorio"] = server.GetEstado();
            tabla_iteraciones.Rows[cantidad_iteraciones]["Cola consultorio"] = cola_clientes.Count();


            tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo ocioso acumulado en la jornada"] = acumulador_tiempo_ocioso_en_jornada.ToString();
            tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo ocioso acumulado total"] = acumulador_tiempo_ocioso_total.ToString();

            tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo en consultorio acumulado en la jornada"] = acumulador_tiempo_consultorio_en_jornada.ToString();
            tabla_iteraciones.Rows[cantidad_iteraciones]["Tiempo en consultorio acumulado total"] = acumulador_tiempo_consultorio_total.ToString();

            //Clientes
            if (mostrar_pacientes)
            {
                string estado_cliente_nro = "Estado paciente" + nro_cliente.ToString();
                string hora_llegada_cliente_nro = "Hora llegada paciente" + nro_cliente.ToString();
                int estado_cliente;
                string estado_cliente_string;
                for (int i = 0; i < clientes_a_mostrar.Count; i++)
                {
                    estado_cliente = (int)clientes_a_mostrar[i].GetEstado();
                    if (estado_cliente == 0) { estado_cliente_string = "EA"; }
                    else if (estado_cliente == 1) { estado_cliente_string = "SA"; }
                    else { estado_cliente_string = "FDS"; }

                    tabla_iteraciones.Rows[cantidad_iteraciones]["Estado paciente " + (i + nro_cliente_desde_que_se_muestra).ToString()] = estado_cliente_string;
                    tabla_iteraciones.Rows[cantidad_iteraciones]["Hora llegada paciente " + (i + nro_cliente_desde_que_se_muestra).ToString()] = clientes_a_mostrar[i].GetMinutoLlegadaAlSistema();
                }
            }
        }

        private void btn_volver_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
