using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaClaro.Application.Models.View
{
    public class ViewMarcaEquipoModel: ViewModelBase<int>
    {
        public string Marca
        {
            get;
            set;
        }
    }
}
