using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_SIMULACION
{
    class servidor
    {
        public enum Estados { libre, ocupado };
        private Estados estado;

        private double fin_atencion;
        private double inicio_atencion;
        private double inicio_ocio;

        private cliente cliente_atendido;

        public servidor()
        {
            this.estado = Estados.libre;
            this.fin_atencion = 0.01;
        }

        public Estados GetEstado()
        {
            return this.estado;
        }
        public void SetEstado(Estados estado)
        {
            this.estado = estado;
        }

        public void SetFinAtencion(double hora_fin_atencion)
        {
            this.fin_atencion = hora_fin_atencion;
        }
        public double GetFinAtencion()
        {
            return this.fin_atencion;
        }

        public void SetCliente(cliente cliente_atendido)
        {
            this.cliente_atendido = cliente_atendido;
        }
        public cliente GetCliente()
        {
            return cliente_atendido;
        }

        public void SetInicioOcio(double hora_inicio_ocio)
        {
            this.inicio_ocio = hora_inicio_ocio;
        }
        public double GetInicioOcio()
        {
            return this.inicio_ocio;
        }

        public void SetInicioAtencion(double hora_inicio_atencion)
        {
            this.inicio_atencion = hora_inicio_atencion;
        }
        public double GetInicioAtencion()
        {
            return this.inicio_atencion;
        }
    }
}
