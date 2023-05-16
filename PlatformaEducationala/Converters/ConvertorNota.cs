using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorNota : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string materie = (string)values[0];
            string elev = (string)values[5];
            int materieId = -1;
            int valoare;
            int semestru;
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
            if (!int.TryParse(values[1].ToString(), out valoare))
            { 
                return null; 
            }
            if (!int.TryParse(values[3].ToString(), out semestru))
            {
                return null;
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
            return new Nota()
            {
                IdMaterie = materieId,
                Valoare = valoare,
                EsteTeza = System.Convert.ToBoolean(values[2].ToString()),
                Semestru = semestru,
                MedieIncheiata = System.Convert.ToBoolean(values[4].ToString()),
                IdElev = elevId
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Nota nota = value as Nota;
            object[] rezultat = new object[6] { nota.IdMaterie, nota.Valoare, nota.EsteTeza, nota.Semestru, nota.MedieIncheiata, nota.IdElev };
            return rezultat;
        }
    }
}
