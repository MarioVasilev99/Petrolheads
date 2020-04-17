namespace Petrolheads.Web.ViewModels.Posts
{
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class PostImageViewModel : IMapFrom<PostImage>
    {
        public string ImageUrl { get; set; }
    }
}