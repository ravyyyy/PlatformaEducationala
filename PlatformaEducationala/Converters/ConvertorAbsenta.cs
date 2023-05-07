using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorAbsenta : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int materieId;
            int elevId;
            if (!int.TryParse(values[0].ToString(), out materieId))
            {
                return null;
            }
            if (!int.TryParse(values[1].ToString(), out elevId))
            {
                return null;
            }
            DateTime date;
            if (DateTime.TryParse(values[2].ToString(), out date))
            {
                return new Absenta()
                {
                    IdMaterie = materieId,
                    IdElev = elevId,
                    DataAbsenta = date,
                    EsteMotivata = System.Convert.ToBoolean(values[3].ToString())
                };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Absenta absenta = value as Absenta;
            object[] rezultat = new object[4] { absenta.IdMaterie, absenta.IdElev, absenta.DataAbsenta, absenta.EsteMotivata };
            return rezultat;
        }
    }
}
