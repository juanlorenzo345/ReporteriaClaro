using ReporteriaClaro.Application.Models.Input.Delete;
using ReporteriaClaro.Application.Models.Input.Insert;
using ReporteriaClaro.Application.Models.Output;
using ReporteriaClaro.Application.Models.Pagination;
using ReporteriaClaro.Application.Models.Sorting;
using ReporteriaClaro.Application.Models.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaClaro.Application.Interfaces.Services.Data
{
    public interface IEquipoScrapService
    {
        public Task<Result<IEnumerable<EquipoScrapEntityDto>>> ObtenerListaEquiposAsync(string serie);

        public Task<Result<PagedResult<EquipoScrapEntityDto>>> ObtenerListaEquiposPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);

        public Task<Result> CrearEquipoScrapAsync(NewEquipoScrapModel modelo);

        public Task<Result> EliminarEquipoScrapAsync(DeleteModelBase<int> modelo);
    }
}
