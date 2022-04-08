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

    public static partial class IdentityUserClaimEntityConverter
    {

        public static IdentityUserClaimEntityDto ToDto(this ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static IdentityUserClaimEntityDto ToDtoWithRelated(this ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new IdentityUserClaimEntityDto();

            // Properties
            target.Id = source.Id;
            target.CreatedAt = source.CreatedAt;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedAt = source.ModifiedAt;
            target.ModifiedBy = source.ModifiedBy;
            target.DeactivatedAt = source.DeactivatedAt;
            target.DeactivatedBy = source.DeactivatedBy;
            target.UserId = source.UserId;
            target.ClaimType = source.ClaimType;
            target.ClaimValue = source.ClaimValue;

            // Navigation Properties
            if (level > 0) {
              target.IdentityUserEntity = source.IdentityUserEntity.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity ToEntity(this IdentityUserClaimEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity();

            // Properties
            target.Id = source.Id;
            target.CreatedAt = source.CreatedAt;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedAt = source.ModifiedAt;
            target.ModifiedBy = source.ModifiedBy;
            target.DeactivatedAt = source.DeactivatedAt;
            target.DeactivatedBy = source.DeactivatedBy;
            target.UserId = source.UserId;
            target.ClaimType = source.ClaimType;
            target.ClaimValue = source.ClaimValue;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<IdentityUserClaimEntityDto> ToDtos(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<IdentityUserClaimEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity> ToEntities(this IEnumerable<IdentityUserClaimEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity source, IdentityUserClaimEntityDto target);

        static partial void OnEntityCreating(IdentityUserClaimEntityDto source, ReporteriaMovistar.Domain.Models.Entities.IdentityUserClaimEntity target);

    }

}
