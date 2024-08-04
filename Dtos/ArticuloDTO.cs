using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ArticuloDTO : IIdGenerico, IValidacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Codigo { get; set; }
        public double PrecioLista { get; set; }
        public int Stock { get; set; }

        public void Validar()
        {
            Util.ThrowExceptionIfItsEmpty(Nombre, "Debe ingresar el nombre del articulo");
            Util.ThrowExceptionIfItsEmpty(Descripcion, "Debe ingresar la descripcion del articulo");
            Util.ThrowExceptionIfItsCero(Codigo, "El codigo no puede ser igual a 0");
            Util.ThrowExceptionIfItsCero(PrecioLista, "El precio de lista no puede ser igual a 0");
            Util.ThrowExceptionIfNegativeNumber(Codigo, "El codigo no puede ser menor a 0");
            Util.ThrowExceptionIfNegativeNumber(PrecioLista, "El precio de lista no puede ser menor a 0");
            Util.ThrowExceptionIfNegativeNumber(Stock, "El stock no puede ser menor a 0");
            ValidacionesExceptions();
        }

        private static readonly int largoDesc = 5;
        public void ValidacionesExceptions()
        {
            if (Descripcion.Length < largoDesc)
            {
                throw new ElementoInvalidoException("La descripcion debe tener al menos 5 caracteres");
            }
            if (Nombre.Length < 10 || Nombre.Length > 200)
            {
                throw new ElementoInvalidoException("El nombre debe tener entre 10 y 200 caracteres");
            }
        }
    }
}
