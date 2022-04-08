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

    public static partial class EquipoModeloEntityConverter
    {

        public static EquipoModeloEntityDto ToDto(this ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static EquipoModeloEntityDto ToDtoWithRelated(this ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new EquipoModeloEntityDto();

            // Properties
            target.Id = source.Id;
            target.Nombre = source.Nombre;
            target.MarcaId = source.MarcaId;
            target.TecnologiaId = source.TecnologiaId;
            target.FechaCreacionRegistro = source.FechaCreacionRegistro;
            target.UsuarioCreacionRegistro = source.UsuarioCreacionRegistro;
            target.FechaModificacionRegistro = source.FechaModificacionRegistro;
            target.UsuarioModificacionRegistro = source.UsuarioModificacionRegistro;
            target.FechaEliminacionRegistro = source.FechaEliminacionRegistro;
            target.UsuarioEliminacionRegistro = source.UsuarioEliminacionRegistro;
            target.Activo = source.Activo;

            // Navigation Properties
            if (level > 0) {
              target.EquipoMarcaEntity = source.EquipoMarcaEntity.ToDtoWithRelated(level - 1);
              target.EquipoTecnologiaEntity = source.EquipoTecnologiaEntity.ToDtoWithRelated(level - 1);
              target.EquipoEntities = source.EquipoEntities.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity ToEntity(this EquipoModeloEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity();

            // Properties
            target.Id = source.Id;
            target.Nombre = source.Nombre;
            target.MarcaId = source.MarcaId;
            target.TecnologiaId = source.TecnologiaId;
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

        public static List<EquipoModeloEntityDto> ToDtos(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<EquipoModeloEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity> ToEntities(this IEnumerable<EquipoModeloEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity source, EquipoModeloEntityDto target);

        static partial void OnEntityCreating(EquipoModeloEntityDto source, ReporteriaMovistar.Domain.Models.Entities.EquipoModeloEntity target);

    }

}
