using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WPFCustomMessageBox;

namespace Employex.Utilities
{
    internal class FieldsVerificator
    {
        public static bool VerificateEmail(string email)
        {
            string emailFormat = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, emailFormat))
                return true;
            else
            {
                CustomMessageBox.ShowOK("Asegurese de introducir un correo valido.", "Error de formato de correo", "Aceptar");
                return false;
            }
        }

        public static bool VerificateName(string name)
        {
            Regex rgx = new Regex(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$");
            if (rgx.IsMatch(name))
                return true;
            else
            {
                CustomMessageBox.ShowOK("Asegurese de que el nombre y apellidos solo contenga datos alfabéticos", "Error nombre inválido", "Aceptar");
                return false;
            }
        }

        public static bool VerificatePlace(string name)
        {
            Regex rgx = new Regex(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$");
            if (rgx.IsMatch(name))
                return true;
            else
            {
                CustomMessageBox.ShowOK("Asegurese de que el país o ciudad solo contenga datos alfabéticos", "Error lugar inválido", "Aceptar");
                return false;
            }
        }

        public static bool VerificateOcupation(string name)
        {
            Regex rgx = new Regex(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1\s]+$");
            if (rgx.IsMatch(name))
                return true;
            else
            {
                CustomMessageBox.ShowOK("Asegurese de que la ocupación solo contenga datos alfabéticos", "Error ocupación inválido", "Aceptar");
                return false;
            }
        }

        public static bool VerificatePhone(string phoneNumber)
        {
            Regex rgx = new Regex(@"^\+?[\d- ]{9,}$");
            if (rgx.IsMatch(phoneNumber))
                return true;
            else
            {
                CustomMessageBox.ShowOK("Asegurese de ingresar un numero de telefono correcto", "Error de formato de telefono", "Aceptar");
                return false;
            }
        }

        public static bool VerificatePromedio(string promedio)
        {
            double average = 0;
            bool IsDouble = false;

            try
            {
                average = Convert.ToDouble(promedio);
                IsDouble = true;
            }
            catch (Exception)
            {
            }

            Regex rgx = new Regex(@"^((\d+)((\.\d{1,2})?))$");
            if (rgx.IsMatch(promedio) && average <= 10 && IsDouble)
                return true;
            else
            {
                CustomMessageBox.ShowOK("El promedio no tiene el formato correcto", "Error de formato de promedio", "Aceptar");
                return false;
            }
        }

        public static bool VerificatePostalCode(string matricula)
        {
            Regex rgx = new Regex(@"^\d{5}$");
            if (rgx.IsMatch(matricula))
                return true;
            else
            {
                CustomMessageBox.ShowOK("Asegurese de solo introducir datos numericos como código postal", "Error de formato de codigo postal", "Aceptar");
                return false;
            }
        }
    }
}
