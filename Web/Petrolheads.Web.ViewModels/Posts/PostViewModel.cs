namespace Petrolheads.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Petrolheads.Data.Models;
    using Petrolheads.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string UserUserName { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Description { get; set; }

        public int LikesCount { get; set; }

        public IEnumerable<PostImageViewModel> Images { get; set; }
    }
}
