namespace Petrolheads.Web.ViewModels.Administration.ManageUsers
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;
    using System.Collections.Generic;

    public class ManageUsersAllViewModel : IMapFrom<ApplicationUser>
    {
        public IEnumerable<ManageUsersUserViewModel> Users { get; set; }
    }
}
