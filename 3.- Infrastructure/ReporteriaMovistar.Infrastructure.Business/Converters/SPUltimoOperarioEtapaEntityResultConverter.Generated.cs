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

    public static partial class SPUltimoOperarioEtapaEntityResultConverter
    {

        public static SPUltimoOperarioEtapaEntityResultDto ToDto(this ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SPUltimoOperarioEtapaEntityResultDto ToDtoWithRelated(this ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult source, int level)
        {
            if (source == null)
              return null;

            var target = new SPUltimoOperarioEtapaEntityResultDto();

            // Properties
            target.Id = source.Id;
            target.Nombre = source.Nombre;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult ToEntity(this SPUltimoOperarioEtapaEntityResultDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult();

            // Properties
            target.Id = source.Id;
            target.Nombre = source.Nombre;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SPUltimoOperarioEtapaEntityResultDto> ToDtos(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SPUltimoOperarioEtapaEntityResultDto> ToDtosWithRelated(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult> ToEntities(this IEnumerable<SPUltimoOperarioEtapaEntityResultDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult source, SPUltimoOperarioEtapaEntityResultDto target);

        static partial void OnEntityCreating(SPUltimoOperarioEtapaEntityResultDto source, ReporteriaMovistar.Domain.Models.Entities.SPUltimoOperarioEtapaEntityResult target);

    }

}