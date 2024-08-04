using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PedidoExpressDTO : PedidoDTO
    {

        private static readonly int validarDiasEntrega = 5;
        public override void Validar()
        {
            base.Validar();
            if (EntregaPrometida > FechaPedido.AddDays(validarDiasEntrega))
            {
                throw new ElementoInvalidoException("La fecha de entrega prometida para un pedido express no puede superar los 5 dias");
            }
        }

        public void CalcularRecargo()
        {
            if(EntregaPrometida != FechaPedido)
            {
                PrecioFinal += PrecioFinal * 1.1;
            }
            else
            {
                PrecioFinal += PrecioFinal * 1.15;
            }
        }
    }
}
