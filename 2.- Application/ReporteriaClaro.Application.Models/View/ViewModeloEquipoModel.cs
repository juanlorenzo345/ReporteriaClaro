using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaClaro.Application.Models.View
{
    public class ViewModeloEquipoModel : ViewModelBase<int>
    {
        public string Modelo
        {
            get;
            set;
        }

        public string Marca
        {
	        get;
	        set;
        }

        public string Tecnologia
        {
	        get;
	        set;
        }
    }
}
