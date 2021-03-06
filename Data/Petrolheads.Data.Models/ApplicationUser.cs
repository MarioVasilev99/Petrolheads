﻿// ReSharper disable VirtualMemberCallInConstructor
namespace Petrolheads.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using Petrolheads.Common;
    using Petrolheads.Data.Common.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Cars = new HashSet<Car>();
            this.Followers = new HashSet<Follower>();
            this.Following = new HashSet<Follower>();
            this.CoverPhotoUrl = GlobalConstants.DefaultCoverPhotoUrl;
            this.ProfilePhotoUrl = GlobalConstants.DefaultProfilePhotoUrl;
        }

        public string CoverPhotoUrl { get; set; }

        public string ProfilePhotoUrl { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual IEnumerable<Car> Cars { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }

        public virtual ICollection<Follower> Followers { get; set; }

        public virtual ICollection<Follower> Following { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
