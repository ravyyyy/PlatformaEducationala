using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PlatformaEducationala.Converters
{
    class ConvertorClasa : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int specializareId;
            int diriginteId;
            int anStudiu;
            if (!int.TryParse(values[0].ToString(), out specializareId))
            {
                return null;
            }
            if (!int.TryParse(values[1].ToString(), out diriginteId))
            {
                return null;
            }
            if (!int.TryParse(values[2].ToString(), out anStudiu))
            {
                return null;
            }
            return new Clasa()
            {
                IdSpecializare = specializareId,
                IdDiriginte = diriginteId,
                AnStudiu = anStudiu,
                Grupa = values[3].ToString()
            };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            Clasa clasa = value as Clasa;
            object[] rezultat = new object[4] { clasa.IdSpecializare, clasa.IdDiriginte, clasa.AnStudiu, clasa.Grupa };
            return rezultat;
        }
    }
}
