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

    public static partial class EquipoTecnologiaEntityConverter
    {

        public static EquipoTecnologiaEntityDto ToDto(this ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static EquipoTecnologiaEntityDto ToDtoWithRelated(this ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new EquipoTecnologiaEntityDto();

            // Properties
            target.Id = source.Id;
            target.Nombre = source.Nombre;
            target.FechaCreacionRegistro = source.FechaCreacionRegistro;
            target.UsuarioCreacionRegistro = source.UsuarioCreacionRegistro;
            target.FechaModificacionRegistro = source.FechaModificacionRegistro;
            target.UsuarioModificacionRegistro = source.UsuarioModificacionRegistro;
            target.FechaEliminacionRegistro = source.FechaEliminacionRegistro;
            target.UsuarioEliminacionRegistro = source.UsuarioEliminacionRegistro;
            target.Activo = source.Activo;

            // Navigation Properties
            if (level > 0) {
              target.EquipoModeloEntities = source.EquipoModeloEntities.ToDtosWithRelated(level - 1);
              target.EquipoConfiguracionEntities = source.EquipoConfiguracionEntities.ToDtosWithRelated(level - 1);
              target.PronosticoEntities = source.PronosticoEntities.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity ToEntity(this EquipoTecnologiaEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity();

            // Properties
            target.Id = source.Id;
            target.Nombre = source.Nombre;
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

        public static List<EquipoTecnologiaEntityDto> ToDtos(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<EquipoTecnologiaEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity> ToEntities(this IEnumerable<EquipoTecnologiaEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity source, EquipoTecnologiaEntityDto target);

        static partial void OnEntityCreating(EquipoTecnologiaEntityDto source, ReporteriaMovistar.Domain.Models.Entities.EquipoTecnologiaEntity target);

    }

}