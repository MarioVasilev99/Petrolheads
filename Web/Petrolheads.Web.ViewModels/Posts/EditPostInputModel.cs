namespace Petrolheads.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using Petrolheads.Common;

    public class EditPostInputModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.PostDescriptionMaxLenght, ErrorMessage = "{0} length can't be more than {1}.")]
        public string Description { get; set; }

        public ICollection<IFormFile> Images { get; set; }
    }
}
