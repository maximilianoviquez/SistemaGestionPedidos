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
    public class ClienteDTO : IIdGenerico, IValidacion
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string RUT { get; set; }
        public DireccionClienteDTO DireccionDTO { get; set; }

        public void Validar()
        {
            Util.ThrowExceptionIfEmptyString(RazonSocial, "Debe ingresar una razón social");
            Util.ThrowExceptionIfEmptyString(RUT, "Debe ingresar un numero de RUT");
            ValidacionesExcpetions();
        }

        public void ValidacionesExcpetions()
        {
            if (RUT.Length != 12)
            {
                throw new ElementoInvalidoException("El RUT debe contener 12 dígitos");
            }
        }
    }
}
