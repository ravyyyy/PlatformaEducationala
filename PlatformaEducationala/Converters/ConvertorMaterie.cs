using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorMaterie : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string profesor = (string)values[1];
            int profesorId = -1;
            int anStudiu;
            string[] parts = profesor.Split(new char[] { '[', ']', ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1)
            {
                string lastPart = parts[1].Trim();
                if (!int.TryParse(lastPart, out profesorId))
                {
                    return null;
                }
            }
            if (!int.TryParse(values[3].ToString(), out anStudiu))
            {
                return null;
            }
            return new Materie()
            {
                Nume = values[0].ToString(),
                IdProfesor = profesorId,
                AreTeza = System.Convert.ToBoolean(values[2].ToString()),
                AnStudiu = anStudiu
            };
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Materie materie = value as Materie;
            object[] rezultat = new object[4] { materie.Nume, materie.IdProfesor, materie.AreTeza, materie.AnStudiu };
            return rezultat;
        }
    }
}
