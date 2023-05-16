using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using static System.Net.Mime.MediaTypeNames;

namespace PlatformaEducationala.Converters
{
    class ConvertorAbsenta : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string materie = values[0].ToString();
            string elev = values[1].ToString();
            int materieId = -1;
            int elevId = -1;
            string[] parts = materie.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out materieId))
                {
                    return null;
                }
            }
            parts = elev.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out elevId))
                {
                    return null;
                }
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
