namespace Petrolheads.Services.Data.Administration.Dashboard
{
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Web.ViewModels.Administration.Dashboard;

    public interface IDashboardService
    {
        IndexViewModel GetAppInfo();
    }
}
