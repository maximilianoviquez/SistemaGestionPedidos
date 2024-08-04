using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class LineaPedidoDTO
    {
        public int Id { get; set; }
        public PedidoDTO PedidoDTO { get; set; }
        public int PedidoId { get; set; }
        public ArticuloDTO ArticuloDTO { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }


        private static readonly double IVA = 1.22;

        public void Validar()
        {
            Util.ThrowExceptionIfNegativeNumber(Cantidad, "La cantidad no puede ser menor a 0");
            Util.ThrowExceptionIfNegativeNumber(PrecioUnitario, "El precio unitario no puede ser menor a 0");
        }

        public double GetSubtotalSinImpuestos()
        {
            return Cantidad * PrecioUnitario;
        }

        public double GetSubtotalConImpuestos()
        {
            return GetSubtotalSinImpuestos() * IVA;
        }

        public double GetTotalDeImpuestos()
        {
            return GetSubtotalConImpuestos() - GetSubtotalSinImpuestos();
        }
    }
}
