using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaMovistar.Application.Models.View
{
    public class ViewEstadoDespachoModel : ViewModelBase<int>
    {
        public string Estado
        {
            get;set;
        }

        public int Posicion
        {
	        get;
	        set;
        }
    }
}
