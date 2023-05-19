using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorMaterial : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string materie = (string)values[0];
            int materieId = -1;
            string[] parts = materie.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out materieId))
                {
                    return null;
                }
            }
            return new Material()
            {
                IdMaterie = materieId,
                Fisier = (byte[])values[1]
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Material material = value as Material;
            object[] rezultat = new object[2] { material.IdMaterie, material.Fisier };
            return rezultat;
        }
    }
}
