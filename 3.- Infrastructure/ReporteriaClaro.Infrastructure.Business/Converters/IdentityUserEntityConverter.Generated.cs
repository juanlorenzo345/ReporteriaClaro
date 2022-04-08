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

    public static partial class IdentityUserEntityConverter
    {

        public static IdentityUserEntityDto ToDto(this ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static IdentityUserEntityDto ToDtoWithRelated(this ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity source, int level)
        {
            if (source == null)
              return null;

            var target = new IdentityUserEntityDto();

            // Properties
            target.Id = source.Id;
            target.FullName = source.FullName;
            target.NormalizedFullName = source.NormalizedFullName;
            target.CreatedAt = source.CreatedAt;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedAt = source.ModifiedAt;
            target.ModifiedBy = source.ModifiedBy;
            target.DeactivatedAt = source.DeactivatedAt;
            target.DeactivatedBy = source.DeactivatedBy;
            target.Reason = source.Reason;
            target.Active = source.Active;
            target.UserName = source.UserName;
            target.NormalizedUserName = source.NormalizedUserName;
            target.Email = source.Email;
            target.NormalizedEmail = source.NormalizedEmail;
            target.EmailConfirmed = source.EmailConfirmed;
            target.PasswordHash = source.PasswordHash;
            target.SecurityStamp = source.SecurityStamp;
            target.ConcurrencyStamp = source.ConcurrencyStamp;
            target.PhoneNumber = source.PhoneNumber;
            target.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            target.TwoFactorEnabled = source.TwoFactorEnabled;
            target.LockoutEnd = source.LockoutEnd;
            target.LockoutEnabled = source.LockoutEnabled;
            target.AccessFailedCount = source.AccessFailedCount;

            // Navigation Properties
            if (level > 0) {
              target.IdentityUserAccessLogEntities = source.IdentityUserAccessLogEntities.ToDtosWithRelated(level - 1);
              target.IdentityUserClaimEntities = source.IdentityUserClaimEntities.ToDtosWithRelated(level - 1);
              target.IdentityUserExceptionLogEntities = source.IdentityUserExceptionLogEntities.ToDtosWithRelated(level - 1);
              target.IdentityUserLoginEntities = source.IdentityUserLoginEntities.ToDtosWithRelated(level - 1);
              target.IdentityUserOperationLogEntities = source.IdentityUserOperationLogEntities.ToDtosWithRelated(level - 1);
              target.IdentityUserRoleEntities = source.IdentityUserRoleEntities.ToDtosWithRelated(level - 1);
              target.IdentityUserTokenEntities = source.IdentityUserTokenEntities.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity ToEntity(this IdentityUserEntityDto source)
        {
            if (source == null)
              return null;

            var target = new ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity();

            // Properties
            target.Id = source.Id;
            target.FullName = source.FullName;
            target.NormalizedFullName = source.NormalizedFullName;
            target.CreatedAt = source.CreatedAt;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedAt = source.ModifiedAt;
            target.ModifiedBy = source.ModifiedBy;
            target.DeactivatedAt = source.DeactivatedAt;
            target.DeactivatedBy = source.DeactivatedBy;
            target.Reason = source.Reason;
            target.Active = source.Active;
            target.UserName = source.UserName;
            target.NormalizedUserName = source.NormalizedUserName;
            target.Email = source.Email;
            target.NormalizedEmail = source.NormalizedEmail;
            target.EmailConfirmed = source.EmailConfirmed;
            target.PasswordHash = source.PasswordHash;
            target.SecurityStamp = source.SecurityStamp;
            target.ConcurrencyStamp = source.ConcurrencyStamp;
            target.PhoneNumber = source.PhoneNumber;
            target.PhoneNumberConfirmed = source.PhoneNumberConfirmed;
            target.TwoFactorEnabled = source.TwoFactorEnabled;
            target.LockoutEnd = source.LockoutEnd;
            target.LockoutEnabled = source.LockoutEnabled;
            target.AccessFailedCount = source.AccessFailedCount;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<IdentityUserEntityDto> ToDtos(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<IdentityUserEntityDto> ToDtosWithRelated(this IEnumerable<ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity> ToEntities(this IEnumerable<IdentityUserEntityDto> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity source, IdentityUserEntityDto target);

        static partial void OnEntityCreating(IdentityUserEntityDto source, ReporteriaClaro.Domain.Models.Entities.IdentityUserEntity target);

    }

}
