using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINAL_SIMULACION
{
    class cliente
    {
        private double minuto_llegada_al_sistema;

        public enum Estados
        {
            ESPERANDO_ATENCION = 0,
            SIENDO_ATENDIDO = 1,
            FUERA_DEL_SISTEMA = 2
        };
        private Estados estado;


        public cliente(double hora_actual, Estados estado)
        {
            this.minuto_llegada_al_sistema = hora_actual;
            this.estado = estado;
        }

        public Estados GetEstado()
        {
            return this.estado;
        }

        public void SetEstado(Estados estado)
        {
            this.estado = estado;
        }

        public double GetMinutoLlegadaAlSistema()
        {
            return this.minuto_llegada_al_sistema;
        }
    }
}
