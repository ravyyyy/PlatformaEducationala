using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorElev : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null && values[5] != null && values[6] != null)
            {
                string clasa = values[6].ToString();
                int idClasa = -1;
                string[] parts = clasa.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 1)
                {
                    string lastPart = parts[2].Trim();
                    if (!int.TryParse(lastPart, out idClasa))
                    {
                        return null;
                    }
                }
                DateTime date;
                if (DateTime.TryParse(values[2].ToString(), out date))
                {
                    return new Elev()
                    {
                        Nume = values[0].ToString(),
                        Prenume = values[1].ToString(),
                        DataNastere = date,
                        Adresa = values[3].ToString(),
                        NumarTelefon = values[4].ToString(),
                        Email = values[5].ToString(),
                        IdClasa = idClasa
                    };
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Elev elev = value as Elev;
            object[] rezultat = new object[7] { elev.Nume, elev.Prenume, elev.DataNastere, elev.Adresa, elev.NumarTelefon, elev.Email, elev.IdClasa };
            return rezultat;
        }
    }
}
