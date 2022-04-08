using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaClaro.Application.Models.View
{
    public class ViewScrapModel : ViewModelBase<int>
    {
		public DateTime Fecha
		{
			get;
			set;
		}

		public string Esn
		{
			get;
			set;
		}

		public string Marca
		{
			get;
			set;
		}

		public string Modelo
		{
			get;
			set;
		}

		public string Color
		{
			get;
			set;
		}

		public string Origen
		{
			get;
			set;
		}

		public string Operario
		{
			get;
			set;
		}

		public string Observacion
		{
			get;
			set;
		}
	}
}
