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

    public static partial class IdentityUserRoleEntityConverter
    {

        public static IdentityUserRoleEntityDto ToDto(this ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static IdentityUserRoleEntityDto ToDtoWithRelated(this ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new IdentityUserRoleEntityDto();

            // Properties
            target.UserId = source.UserId;
            target.RoleId = source.RoleId;
            target.CreatedAt = source.CreatedAt;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedAt = source.ModifiedAt;
            target.ModifiedBy = source.ModifiedBy;
            target.DeactivatedAt = source.DeactivatedAt;
            target.DeactivatedBy = source.DeactivatedBy;

            // Navigation Properties
            if (level > 0) {
              target.IdentityRoleEntity = source.IdentityRoleEntity.ToDtoWithRelated(level - 1);
              target.IdentityUserEntity = source.IdentityUserEntity.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity ToEntity(this IdentityUserRoleEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity();

            // Properties
            target.UserId = source.UserId;
            target.RoleId = source.RoleId;
            target.CreatedAt = source.CreatedAt;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedAt = source.ModifiedAt;
            target.ModifiedBy = source.ModifiedBy;
            target.DeactivatedAt = source.DeactivatedAt;
            target.DeactivatedBy = source.DeactivatedBy;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<IdentityUserRoleEntityDto> ToDtos(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<IdentityUserRoleEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity> ToEntities(this IEnumerable<IdentityUserRoleEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity source, IdentityUserRoleEntityDto target);

        static partial void OnEntityCreating(IdentityUserRoleEntityDto source, ReporteriaClaro.Domain.Models.Entities.IdentityUserRoleEntity target);

    }

}
