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

    public static partial class IdentityUserLoginEntityConverter
    {

        public static IdentityUserLoginEntityDto ToDto(this ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static IdentityUserLoginEntityDto ToDtoWithRelated(this ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new IdentityUserLoginEntityDto();

            // Properties
            target.LoginProvider = source.LoginProvider;
            target.ProviderKey = source.ProviderKey;
            target.CreatedAt = source.CreatedAt;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedAt = source.ModifiedAt;
            target.ModifiedBy = source.ModifiedBy;
            target.DeactivatedAt = source.DeactivatedAt;
            target.DeactivatedBy = source.DeactivatedBy;
            target.ProviderDisplayName = source.ProviderDisplayName;
            target.UserId = source.UserId;

            // Navigation Properties
            if (level > 0) {
              target.IdentityUserEntity = source.IdentityUserEntity.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity ToEntity(this IdentityUserLoginEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity();

            // Properties
            target.LoginProvider = source.LoginProvider;
            target.ProviderKey = source.ProviderKey;
            target.CreatedAt = source.CreatedAt;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedAt = source.ModifiedAt;
            target.ModifiedBy = source.ModifiedBy;
            target.DeactivatedAt = source.DeactivatedAt;
            target.DeactivatedBy = source.DeactivatedBy;
            target.ProviderDisplayName = source.ProviderDisplayName;
            target.UserId = source.UserId;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<IdentityUserLoginEntityDto> ToDtos(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<IdentityUserLoginEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity> ToEntities(this IEnumerable<IdentityUserLoginEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity source, IdentityUserLoginEntityDto target);

        static partial void OnEntityCreating(IdentityUserLoginEntityDto source, ReporteriaClaro.Domain.Models.Entities.IdentityUserLoginEntity target);

    }

}
