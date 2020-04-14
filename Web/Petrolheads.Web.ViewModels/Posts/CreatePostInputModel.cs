﻿namespace Petrolheads.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Petrolheads.Common;

    public class CreatePostInputModel
    {
        [Required]
        [StringLength(GlobalConstants.PostDescriptionMaxLenght, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Description { get; set; }

        public ICollection<IFormFile> Images { get; set; }
    }
}
