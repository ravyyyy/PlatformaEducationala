using PlatformaEducationala.Models.DataAccessLayer;
using PlatformaEducationala.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformaEducationala.Models.BusinessLogicLayer
{
    public class AbsentaBLL
    {
        public ObservableCollection<Absenta> ListaAbsente { get; set; }

        AbsentaDAL absentaDAL = new AbsentaDAL();

        public void InserareAbsenta(Absenta absenta)
        {

        }
    }
}
