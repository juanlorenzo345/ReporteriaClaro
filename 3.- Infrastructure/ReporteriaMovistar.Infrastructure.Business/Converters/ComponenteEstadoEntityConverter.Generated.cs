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

    public static partial class ComponenteEstadoEntityConverter
    {

        public static ComponenteEstadoEntityDto ToDto(this ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ComponenteEstadoEntityDto ToDtoWithRelated(this ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new ComponenteEstadoEntityDto();

            // Properties
            target.Id = source.Id;
            target.Nombre = source.Nombre;
            target.Posicion = source.Posicion;
            target.FechaCreacionRegistro = source.FechaCreacionRegistro;
            target.UsuarioCreacionRegistro = source.UsuarioCreacionRegistro;
            target.FechaModificacionRegistro = source.FechaModificacionRegistro;
            target.UsuarioModificacionRegistro = source.UsuarioModificacionRegistro;
            target.FechaEliminacionRegistro = source.FechaEliminacionRegistro;
            target.UsuarioEliminacionRegistro = source.UsuarioEliminacionRegistro;
            target.Activo = source.Activo;

            // Navigation Properties
            if (level > 0) {
              target.EquipoEntities_FuentePoderEstadoId = source.EquipoEntities_FuentePoderEstadoId.ToDtosWithRelated(level - 1);
              target.EquipoEntities_UtpEstadoId = source.EquipoEntities_UtpEstadoId.ToDtosWithRelated(level - 1);
              target.EquipoEntities_ControlRemotoEstadoId = source.EquipoEntities_ControlRemotoEstadoId.ToDtosWithRelated(level - 1);
              target.EquipoEntities_HdmiEstadoId = source.EquipoEntities_HdmiEstadoId.ToDtosWithRelated(level - 1);
              target.EquipoEntities_RcaEstadoId = source.EquipoEntities_RcaEstadoId.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity ToEntity(this ComponenteEstadoEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity();

            // Properties
            target.Id = source.Id;
            target.Nombre = source.Nombre;
            target.Posicion = source.Posicion;
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

        public static List<ComponenteEstadoEntityDto> ToDtos(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ComponenteEstadoEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity> ToEntities(this IEnumerable<ComponenteEstadoEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity source, ComponenteEstadoEntityDto target);

        static partial void OnEntityCreating(ComponenteEstadoEntityDto source, ReporteriaMovistar.Domain.Models.Entities.ComponenteEstadoEntity target);

    }

}
