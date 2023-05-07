using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorMaterial : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int materieId;
            if (!int.TryParse(values[0].ToString(), out materieId))
            {
                return null;
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
