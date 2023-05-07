using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorProfesor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null && values[5] != null && values[6] != null)
            {
                DateTime date;
                if (DateTime.TryParse(values[2].ToString(), out date))
                {
                    return new Profesor()
                    {
                        Nume = values[0].ToString(),
                        Prenume = values[1].ToString(),
                        DataNastere = date,
                        Adresa = values[3].ToString(),
                        NumarTelefon = values[4].ToString(),
                        Email = values[5].ToString(),
                        EsteDiriginte = System.Convert.ToBoolean(values[6].ToString())
                    };
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Profesor profesor = value as Profesor;
            object[] rezultat = new object[7] { profesor.Nume, profesor.Prenume, profesor.DataNastere, profesor.Adresa, profesor.NumarTelefon, profesor.Email, profesor.EsteDiriginte };
            return rezultat;
        }
    }
}
