using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorMedie : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int elevId;
            int materieId;
            decimal nota;
            if (!int.TryParse(values[0].ToString(), out elevId))
            {
                return null;
            }
            if (!int.TryParse(values[1].ToString(), out materieId))
            {
                return null;
            }
            if (!decimal.TryParse(values[2].ToString(), out nota))
            { 
                return null;
            }
            return new Medie()
            {
                IdElev = elevId,
                IdMaterie = materieId,
                Nota = nota
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Medie medie = value as Medie;
            object[] rezultat = new object[3] { medie.IdElev, medie.IdMaterie, medie.Nota };
            return rezultat;
        }
    }
}
