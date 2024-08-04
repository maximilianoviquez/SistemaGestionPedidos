using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class PedidoDTO : IIdGenerico, IValidacion
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime EntregaPrometida { get; set; }
        public ClienteDTO ClienteDTO { get; set; }
        public int ClienteId { get; set; }

        public List<LineaPedidoDTO> LineasPedido = new List<LineaPedidoDTO>();
        public double Subtotal { get; set; }
        public double Impuestos { get; set; }   
        public double PrecioFinal { get; set; }
        public bool PedidoAnulado {  get; set; } = false;

        public virtual void Validar()
        {
            Util.ThrowExceptionIfItsCero(ClienteId, "Debe ingresar un Cliente");
            ValidacionesExceptions();
        }

        public void ValidacionesExceptions()
        {
            if (EntregaPrometida < FechaPedido)
            {
                throw new ElementoInvalidoException("La fecha de entrega prometida no puede ser menor a la fecha del pedido");
            }
        }

        public void CalcularTotales()
        {
            double subtotal = 0;
            double impuestos = 0;
            double total = 0;
            foreach (LineaPedidoDTO lp in LineasPedido)
            {
                subtotal += lp.GetSubtotalSinImpuestos();
                impuestos += lp.GetTotalDeImpuestos();
                total += lp.GetSubtotalConImpuestos();
            }

            Subtotal = subtotal;
            Impuestos = impuestos;
            PrecioFinal = total;
        }

    }
}
