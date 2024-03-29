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

    public static partial class IdentityUserAccessLogEntityConverter
    {

        public static IdentityUserAccessLogEntityDto ToDto(this ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static IdentityUserAccessLogEntityDto ToDtoWithRelated(this ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new IdentityUserAccessLogEntityDto();

            // Properties
            target.Id = source.Id;
            target.UserId = source.UserId;
            target.IpAddress = source.IpAddress;
            target.AccessAt = source.AccessAt;
            target.SuccessfulLogin = source.SuccessfulLogin;
            target.Detail = source.Detail;

            // Navigation Properties
            if (level > 0) {
              target.IdentityUserEntity = source.IdentityUserEntity.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity ToEntity(this IdentityUserAccessLogEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity();

            // Properties
            target.Id = source.Id;
            target.UserId = source.UserId;
            target.IpAddress = source.IpAddress;
            target.AccessAt = source.AccessAt;
            target.SuccessfulLogin = source.SuccessfulLogin;
            target.Detail = source.Detail;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<IdentityUserAccessLogEntityDto> ToDtos(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<IdentityUserAccessLogEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity> ToEntities(this IEnumerable<IdentityUserAccessLogEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity source, IdentityUserAccessLogEntityDto target);

        static partial void OnEntityCreating(IdentityUserAccessLogEntityDto source, ReporteriaClaro.Domain.Models.Entities.IdentityUserAccessLogEntity target);

    }

}
