using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class UsuarioDTO : IIdGenerico , IValidacion
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Admin { get; set; }

        public void Validar()
        {
            Util.ThrowExceptionIfEmptyString(Email, "Debe ingresar una direccion mail");
            Util.ThrowExceptionIfEmptyString(Password, "Debe ingresar una clave");
            Util.ThrowExceptionIfEmptyString(Nombre, "Debe ingresar un nombre");
            Util.ThrowExceptionIfEmptyString(Apellido, "Debe ingresar una apellido");
            ValidacionesExceptions();
        }

        public bool MailValido(string mail)
        {
            try
            {
                MailAddress correo = new MailAddress(mail);          //intenta crear una instancia de MailAdress con el mail ingresado
                return true;                                         //si no lanza excepcion, el correo es valido
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public bool PassValida(string pass)
        {
            bool tieneMayusc = pass.Any(char.IsUpper);
            bool tieneMinusc = pass.Any(char.IsLower);
            bool tieneDigito = pass.Any(char.IsDigit);
            bool tienePuntuacion = pass.Any(char.IsPunctuation);

            if (pass.Length < 6 || pass == null)                    //La pass no puede tener menos de 6 char o ser nula
            {
                return false;
            }

            return tieneMayusc && tieneMinusc && tieneDigito && tienePuntuacion;            //si tiene los char declarados en las variables, retorna true

        }

        public bool NombreValido(string nombre)
        {
            if (!char.IsLetter(nombre.First()) || !char.IsLetter(nombre.Last()))             //si la primera o ultima letra no son letras alfabeticas, retorna false
            {
                return false;
            }

            return nombre.Any(c => char.IsLetter(c) || c == ' ' || c == '\'' || c == '-');   //los caracteres del nombre pueden ser letras, espacio, apostrofe o guion
        }

        public void ValidacionesExceptions()
        {
            if (!MailValido(Email))
            {
                throw new ElementoInvalidoException("Direccion de correo invalida");
            }

            if (!PassValida(Password))
            {
                throw new ElementoInvalidoException("La contraseña no es valida, verifiquie si cumple con las siguientes consignas: \n" +
                                                    "- Largo minimo de 6 caracteres \n" +
                                                    "- 1 mayúscula \n" +
                                                    "- 1 mayúscula \n" +
                                                    "- 1 dígito \n" +
                                                    "- 1 carácter de puntuación");
            }

            if (!NombreValido(Nombre))
            {
                throw new ElementoInvalidoException("El nombre no es valido, verifiquie si cumple con las siguientes consignas: \n" +
                                                    "- El primer caracter debe ser una letra \n" +
                                                    "- El ultimo caracter debe ser una letra \n" +
                                                    "- Unicamente puede contener letras, espacios, apóstrofes o guiónes");
            }

            if (!NombreValido(Apellido))
            {
                throw new ElementoInvalidoException("El apellido no es valido, verifiquie si cumple con las siguientes consignas: \n" +
                                                    "- El primer caracter debe ser una letra \n" +
                                                    "- El ultimo caracter debe ser una letra \n" +
                                                    "- Unicamente puede contener letras, espacios, apóstrofes o guiónes");
            }
        }
    }
}
