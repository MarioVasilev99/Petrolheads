namespace Petrolheads.Web.ViewModels.Administration.ManageUsers
{
    using System;

    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class ManageUsersUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
