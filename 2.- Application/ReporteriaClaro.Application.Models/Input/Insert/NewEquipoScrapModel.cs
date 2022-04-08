using ReporteriaClaro.Application.Models.Input.Choice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaClaro.Application.Models.Input.Insert
{
    public class NewEquipoScrapModel : NewModelBase
    {
        public int Id
        {
            get;
            set;
        }

        public DateTime? Fecha
        {
            get;
            set;
        }

        public string Origen
        {
            get;
            set;
        }

        public string Detalle
        {
            get;
            set;
        }

        public ChoiceEtapaModel EtapaOrigen
        {
            get;
            set;
        } = new ChoiceEtapaModel() { Id = -1, Nombre = string.Empty, Zona = string.Empty };
    }
}
