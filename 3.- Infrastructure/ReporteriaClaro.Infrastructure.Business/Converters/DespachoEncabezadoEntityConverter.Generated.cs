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

    public static partial class DespachoEncabezadoEntityConverter
    {

        public static DespachoEncabezadoEntityDto ToDto(this ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DespachoEncabezadoEntityDto ToDtoWithRelated(this ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new DespachoEncabezadoEntityDto();

            // Properties
            target.Id = source.Id;
            target.Guia = source.Guia;
            target.Fecha = source.Fecha;
            target.EstadoId = source.EstadoId;
            target.FechaCreacionRegistro = source.FechaCreacionRegistro;
            target.UsuarioCreacionRegistro = source.UsuarioCreacionRegistro;
            target.FechaModificacionRegistro = source.FechaModificacionRegistro;
            target.UsuarioModificacionRegistro = source.UsuarioModificacionRegistro;
            target.FechaEliminacionRegistro = source.FechaEliminacionRegistro;
            target.UsuarioEliminacionRegistro = source.UsuarioEliminacionRegistro;
            target.Activo = source.Activo;

            // Navigation Properties
            if (level > 0) {
              target.DespachoDetalleEntities = source.DespachoDetalleEntities.ToDtosWithRelated(level - 1);
              target.DespachoEstadoEntity = source.DespachoEstadoEntity.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity ToEntity(this DespachoEncabezadoEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity();

            // Properties
            target.Id = source.Id;
            target.Guia = source.Guia;
            target.Fecha = source.Fecha;
            target.EstadoId = source.EstadoId;
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

        public static List<DespachoEncabezadoEntityDto> ToDtos(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DespachoEncabezadoEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity> ToEntities(this IEnumerable<DespachoEncabezadoEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity source, DespachoEncabezadoEntityDto target);

        static partial void OnEntityCreating(DespachoEncabezadoEntityDto source, ReporteriaClaro.Domain.Models.Entities.DespachoEncabezadoEntity target);

    }

}
