﻿namespace Petrolheads.Services.Data
{
    using System.Collections.Generic;

    using Petrolheads.Web.ViewModels.Cars;

    public interface IMakesService
    {
        IEnumerable<MakeViewModel> GetAll();
    }
}
