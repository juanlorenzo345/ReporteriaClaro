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

namespace ReporteriaClaro.Application.Models.Transfer
{

    public static partial class DespachoDetalleEntityConverter
    {

        public static DespachoDetalleEntityDto ToDto(this ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DespachoDetalleEntityDto ToDtoWithRelated(this ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new DespachoDetalleEntityDto();

            // Properties
            target.Id = source.Id;
            target.EquipoId = source.EquipoId;
            target.EncabezadoId = source.EncabezadoId;
            target.Caja = source.Caja;
            target.Pallet = source.Pallet;
            target.FechaCreacionRegistro = source.FechaCreacionRegistro;
            target.UsuarioCreacionRegistro = source.UsuarioCreacionRegistro;
            target.FechaModificacionRegistro = source.FechaModificacionRegistro;
            target.UsuarioModificacionRegistro = source.UsuarioModificacionRegistro;
            target.FechaEliminacionRegistro = source.FechaEliminacionRegistro;
            target.UsuarioEliminacionRegistro = source.UsuarioEliminacionRegistro;
            target.Activo = source.Activo;

            // Navigation Properties
            if (level > 0) {
              target.DespachoEncabezadoEntity = source.DespachoEncabezadoEntity.ToDtoWithRelated(level - 1);
              target.EquipoEntity = source.EquipoEntity.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity ToEntity(this DespachoDetalleEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity();

            // Properties
            target.Id = source.Id;
            target.EquipoId = source.EquipoId;
            target.EncabezadoId = source.EncabezadoId;
            target.Caja = source.Caja;
            target.Pallet = source.Pallet;
            target.FechaCreacionRegistro = source.FechaCreacionRegistro;
            target.UsuarioCreacionRegistro = source.UsuarioCreacionRegistro;
            target.FechaModificacionRegistro = source.FechaModificacionRegistro;
            target.UsuarioModificacionRegistro = source.UsuarioModificacionRegistro;
            target.FechaEliminacionRegistro = source.FechaEliminacionRegistro;
            target.UsuarioEliminacionRegistro = source.UsuarioEliminacionRegistro;
            target.Activo = source.Activo;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DespachoDetalleEntityDto> ToDtos(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DespachoDetalleEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity> ToEntities(this IEnumerable<DespachoDetalleEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity source, DespachoDetalleEntityDto target);

        static partial void OnEntityCreating(DespachoDetalleEntityDto source, ReporteriaClaro.Domain.Models.Entities.DespachoDetalleEntity target);

    }

}
