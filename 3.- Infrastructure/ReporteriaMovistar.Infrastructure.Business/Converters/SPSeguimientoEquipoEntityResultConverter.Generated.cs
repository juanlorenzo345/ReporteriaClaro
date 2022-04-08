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

    public static partial class SPSeguimientoEquipoEntityResultConverter
    {

        public static SPSeguimientoEquipoEntityResultDto ToDto(this ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SPSeguimientoEquipoEntityResultDto ToDtoWithRelated(this ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult source, int level)
        {
            if (source == null)
              return null;

            var target = new SPSeguimientoEquipoEntityResultDto();

            // Properties
            target.Id = source.Id;
            target.FechaRecepcion = source.FechaRecepcion;
            target.Esn = source.Esn;
            target.Marca = source.Marca;
            target.Modelo = source.Modelo;
            target.Color = source.Color;
            target.Tecnologia = source.Tecnologia;
            target.Configuracion = source.Configuracion;
            target.DetalleConfiguracion = source.DetalleConfiguracion;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult ToEntity(this SPSeguimientoEquipoEntityResultDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult();

            // Properties
            target.Id = source.Id;
            target.FechaRecepcion = source.FechaRecepcion;
            target.Esn = source.Esn;
            target.Marca = source.Marca;
            target.Modelo = source.Modelo;
            target.Color = source.Color;
            target.Tecnologia = source.Tecnologia;
            target.Configuracion = source.Configuracion;
            target.DetalleConfiguracion = source.DetalleConfiguracion;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SPSeguimientoEquipoEntityResultDto> ToDtos(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SPSeguimientoEquipoEntityResultDto> ToDtosWithRelated(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult> ToEntities(this IEnumerable<SPSeguimientoEquipoEntityResultDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult source, SPSeguimientoEquipoEntityResultDto target);

        static partial void OnEntityCreating(SPSeguimientoEquipoEntityResultDto source, ReporteriaMovistar.Domain.Models.Entities.SPSeguimientoEquipoEntityResult target);

    }

}