using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaMovistar.Application.Models.View
{
    public class ViewColorEquipoModel: ViewModelBase<int>
    {
        public string Color
        {
            get;
            set;
        }
    }
}
