using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ReporteriaClaro.Clients.BlazorServerSide.IdentityData.Models
{
    public class ApplicationUser : IdentityUser
    {
	    [MaxLength(256)]
	    public string FullName
	    {
		    get;
		    set;
	    }

	    [MaxLength(256)]
	    public string NormalizedFullName
		{
		    get;
		    set;
	    }

	    public virtual IList<ApplicationUserAccessLog> UserAccessLogs
	    {
		    get;
		    set;
	    }

	    public virtual IList<ApplicationUserOperationLog> UserOperationLogs
	    {
		    get;
		    set;
	    }

	    public virtual IList<ApplicationUserExceptionLog> UserExceptionLogs
	    {
		    get;
		    set;
	    }

		[Required]
		public DateTime CreatedAt
	    {
		    get;
		    set;
	    }

	    [Required]
	    [MaxLength(256)]
	    public string CreatedBy
	    {
		    get;
		    set;
	    }

	    public DateTime? ModifiedAt
	    {
		    get;
		    set;
	    }

	    [MaxLength(256)]
	    public string ModifiedBy
	    {
		    get;
		    set;
	    }

	    public DateTime? DeactivatedAt
	    {
		    get;
		    set;
	    }

	    [MaxLength(256)]
	    public string DeactivatedBy
	    {
		    get;
		    set;
	    }

		[MaxLength(200)]
	    public string Reason
	    {
		    get;
		    set;
	    }

	    [Required]
	    public bool Active
	    {
		    get;
		    set;
	    }
    }
}
