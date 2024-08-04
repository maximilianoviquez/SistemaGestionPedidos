using Domain.Exceptions;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PedidoComunDTO : PedidoDTO
    {

        private static readonly int validarDiasEntrega = 7;
        public override void Validar()
        {
            base.Validar();
            if(EntregaPrometida < FechaPedido.AddDays(validarDiasEntrega))
            {
                throw new ElementoInvalidoException("La fecha de entrega prometida para un pedido comun no puede ser menor a una semana");
            }
        }

        public void CalcularRecargo()
        {
            if (ClienteDTO.DireccionDTO.DistanciaKM > 100)
            {
                PrecioFinal += PrecioFinal * 1.05;
            }
        }
    }
}
