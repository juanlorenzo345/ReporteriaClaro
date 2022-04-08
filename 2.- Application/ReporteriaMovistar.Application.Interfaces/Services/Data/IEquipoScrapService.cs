using ReporteriaMovistar.Application.Models.Input.Delete;
using ReporteriaMovistar.Application.Models.Input.Insert;
using ReporteriaMovistar.Application.Models.Output;
using ReporteriaMovistar.Application.Models.Pagination;
using ReporteriaMovistar.Application.Models.Sorting;
using ReporteriaMovistar.Application.Models.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReporteriaMovistar.Application.Interfaces.Services.Data
{
    public interface IEquipoScrapService
    {
        public Task<Result<IEnumerable<EquipoScrapEntityDto>>> ObtenerListaEquiposAsync(string serie);

        public Task<Result<PagedResult<EquipoScrapEntityDto>>> ObtenerListaEquiposPaginadoAsync(bool mostrarEliminados, PagerInfo pagerInfo, SortingInfo sortingInfo);

        public Task<Result> CrearEquipoScrapAsync(NewEquipoScrapModel modelo);

        public Task<Result> EliminarEquipoScrapAsync(DeleteModelBase<int> modelo);
    }
}
