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

namespace ReporteriaMovistar.Application.Models.Transfer
{

    public partial class IdentityUserEntityDto
    {
        #region Constructors

        public IdentityUserEntityDto() {
        }

        public IdentityUserEntityDto(string id, string fullName, string normalizedFullName, System.DateTime createdAt, string createdBy, System.DateTime? modifiedAt, string modifiedBy, System.DateTime? deactivatedAt, string deactivatedBy, string reason, bool active, string userName, string normalizedUserName, string email, string normalizedEmail, bool emailConfirmed, string passwordHash, string securityStamp, string concurrencyStamp, string phoneNumber, bool phoneNumberConfirmed, bool twoFactorEnabled, System.DateTimeOffset? lockoutEnd, bool lockoutEnabled, int accessFailedCount, List<IdentityUserAccessLogEntityDto> identityUserAccessLogEntities, List<IdentityUserClaimEntityDto> identityUserClaimEntities, List<IdentityUserExceptionLogEntityDto> identityUserExceptionLogEntities, List<IdentityUserLoginEntityDto> identityUserLoginEntities, List<IdentityUserOperationLogEntityDto> identityUserOperationLogEntities, List<IdentityUserRoleEntityDto> identityUserRoleEntities, List<IdentityUserTokenEntityDto> identityUserTokenEntities) {

          this.Id = id;
          this.FullName = fullName;
          this.NormalizedFullName = normalizedFullName;
          this.CreatedAt = createdAt;
          this.CreatedBy = createdBy;
          this.ModifiedAt = modifiedAt;
          this.ModifiedBy = modifiedBy;
          this.DeactivatedAt = deactivatedAt;
          this.DeactivatedBy = deactivatedBy;
          this.Reason = reason;
          this.Active = active;
          this.UserName = userName;
          this.NormalizedUserName = normalizedUserName;
          this.Email = email;
          this.NormalizedEmail = normalizedEmail;
          this.EmailConfirmed = emailConfirmed;
          this.PasswordHash = passwordHash;
          this.SecurityStamp = securityStamp;
          this.ConcurrencyStamp = concurrencyStamp;
          this.PhoneNumber = phoneNumber;
          this.PhoneNumberConfirmed = phoneNumberConfirmed;
          this.TwoFactorEnabled = twoFactorEnabled;
          this.LockoutEnd = lockoutEnd;
          this.LockoutEnabled = lockoutEnabled;
          this.AccessFailedCount = accessFailedCount;
          this.IdentityUserAccessLogEntities = identityUserAccessLogEntities;
          this.IdentityUserClaimEntities = identityUserClaimEntities;
          this.IdentityUserExceptionLogEntities = identityUserExceptionLogEntities;
          this.IdentityUserLoginEntities = identityUserLoginEntities;
          this.IdentityUserOperationLogEntities = identityUserOperationLogEntities;
          this.IdentityUserRoleEntities = identityUserRoleEntities;
          this.IdentityUserTokenEntities = identityUserTokenEntities;
        }

        #endregion

        #region Properties

        public string Id { get; set; }

        public string FullName { get; set; }

        public string NormalizedFullName { get; set; }

        public System.DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public System.DateTime? ModifiedAt { get; set; }

        public string ModifiedBy { get; set; }

        public System.DateTime? DeactivatedAt { get; set; }

        public string DeactivatedBy { get; set; }

        public string Reason { get; set; }

        public bool Active { get; set; }

        public string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string ConcurrencyStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public System.DateTimeOffset? LockoutEnd { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        #endregion

        #region Navigation Properties

        public List<IdentityUserAccessLogEntityDto> IdentityUserAccessLogEntities { get; set; }

        public List<IdentityUserClaimEntityDto> IdentityUserClaimEntities { get; set; }

        public List<IdentityUserExceptionLogEntityDto> IdentityUserExceptionLogEntities { get; set; }

        public List<IdentityUserLoginEntityDto> IdentityUserLoginEntities { get; set; }

        public List<IdentityUserOperationLogEntityDto> IdentityUserOperationLogEntities { get; set; }

        public List<IdentityUserRoleEntityDto> IdentityUserRoleEntities { get; set; }

        public List<IdentityUserTokenEntityDto> IdentityUserTokenEntities { get; set; }

        #endregion
    }

}