﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 10-12-2021 02:28:29 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public static partial class TempEquipoMovimientoCsvEntityConverter
    {

        public static TempEquipoMovimientoCsvEntityDto ToDto(this ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TempEquipoMovimientoCsvEntityDto ToDtoWithRelated(this ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new TempEquipoMovimientoCsvEntityDto();

            // Properties
            target.Id = source.Id;
            target.Fecha = source.Fecha;
            target.Esn = source.Esn;
            target.Operario = source.Operario;
            target.OperarioDevolucion = source.OperarioDevolucion;
            target.Observacion = source.Observacion;
            target.EquipoId = source.EquipoId;
            target.OperarioId = source.OperarioId;
            target.OperarioDevolucionId = source.OperarioDevolucionId;
            target.FechaCreacionRegistro = source.FechaCreacionRegistro;
            target.UsuarioCreacionRegistro = source.UsuarioCreacionRegistro;
            target.CargaExitosa = source.CargaExitosa;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity ToEntity(this TempEquipoMovimientoCsvEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity();

            // Properties
            target.Id = source.Id;
            target.Fecha = source.Fecha;
            target.Esn = source.Esn;
            target.Operario = source.Operario;
            target.OperarioDevolucion = source.OperarioDevolucion;
            target.Observacion = source.Observacion;
            target.EquipoId = source.EquipoId;
            target.OperarioId = source.OperarioId;
            target.OperarioDevolucionId = source.OperarioDevolucionId;
            target.FechaCreacionRegistro = source.FechaCreacionRegistro;
            target.UsuarioCreacionRegistro = source.UsuarioCreacionRegistro;
            target.CargaExitosa = source.CargaExitosa;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TempEquipoMovimientoCsvEntityDto> ToDtos(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TempEquipoMovimientoCsvEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity> ToEntities(this IEnumerable<TempEquipoMovimientoCsvEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity source, TempEquipoMovimientoCsvEntityDto target);

        static partial void OnEntityCreating(TempEquipoMovimientoCsvEntityDto source, ReporteriaMovistar.Domain.Models.Entities.TempEquipoMovimientoCsvEntity target);

    }

}
