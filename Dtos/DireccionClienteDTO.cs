using Domain.Interfaces;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class DireccionClienteDTO : IValidacion
    {
        public string Calle { get; set; }
        public int NumeroPuerta { get; set; }
        public string Ciudad { get; set; }
        public int DistanciaKM { get; set; }

        public void Validar()
        {
            Util.ThrowExceptionIfEmptyString(Calle, "Debe ingresar una calle");
            Util.ThrowExceptionIfEmptyString(Ciudad, "Debe ingresar una ciudad");
            Util.ThrowExceptionIfNegativeNumber(NumeroPuerta, "Numero de puerta invalido");
            Util.ThrowExceptionIfNegativeNumber(DistanciaKM, "La distancia no puede ser menor a 0KM");
        }
    }
}
