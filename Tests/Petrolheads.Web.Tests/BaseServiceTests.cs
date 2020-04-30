namespace Petrolheads.Web.Tests
{
    using System;
    using System.IO;
    using System.Linq;

    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Petrolheads.Data;
    using Petrolheads.Data.Common;
    using Petrolheads.Data.Common.Repositories;
    using Petrolheads.Data.Models;
    using Petrolheads.Data.Repositories;
    using Petrolheads.Services.Data.Administration.Dashboard;
    using Petrolheads.Services.Data.Administration.ManageCars;
    using Petrolheads.Services.Data.Administration.ManageMakes;
    using Petrolheads.Services.Data.Administration.ManagePosts;
    using Petrolheads.Services.Data.Administration.ManageUsers;
    using Petrolheads.Services.Data.Cars;
    using Petrolheads.Services.Data.Follows;
    using Petrolheads.Services.Data.Likes;
    using Petrolheads.Services.Data.Makes;
    using Petrolheads.Services.Data.Posts;
    using Petrolheads.Services.Data.Profiles;
    using Petrolheads.Services.Data.Settings;
    using Petrolheads.Services.Messaging;

    public abstract class BaseServiceTests : IDisposable
    {

        public BaseServiceTests()
        {
            this.Configuration = this.SetConfiguration();
            var services = this.SetServices();
            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            this.Seed();
        }

        protected IServiceProvider ServiceProvider { get; set; }

        protected ApplicationDbContext DbContext { get; set; }

        protected IConfigurationRoot Configuration { get; set; }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            this.SetServices();
        }

        private IConfigurationRoot SetConfiguration()
        {
            return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                 path: "appsettings.json",
                 optional: false,
                 reloadOnChange: true)
           .Build();
        }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(
               options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            services
                 .AddIdentity<ApplicationUser, ApplicationRole>(options =>
                 {
                     options.Password.RequireDigit = false;
                     options.Password.RequireLowercase = false;
                     options.Password.RequireUppercase = false;
                     options.Password.RequireNonAlphanumeric = false;
                     options.Password.RequiredLength = 6;
                 })
                 .AddEntityFrameworkStores<ApplicationDbContext>();

            Account account = new Account(
                "dnzfktppn",
                "843138318639933",
                "AwisvCyUdOsg3XBBg-yU_kFLBgc");

            Cloudinary cloudinary = new Cloudinary(account);

            services.AddSingleton(this.Configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender>(x => new SendGridEmailSender("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"));
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IProfilesService, ProfilesService>();
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<ILikesService, LikesService>();
            services.AddTransient<IMakesService, MakesService>();
            services.AddTransient<ICarsService, CarsService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IManagePostsService, ManagePostsService>();
            services.AddTransient<IManageCarsService, ManageCarsService>();
            services.AddTransient<IManageMakesService, ManageMakesService>();
            services.AddTransient<IManageUsersService, ManageUsersService>();
            services.AddTransient<IFollowsService, FollowsService>();
            services.AddSingleton(cloudinary);

            return services;
        }

        private void Seed()
        {
            var make = new Make()
            {
                Name = "BMW",
            };

            this.DbContext.Makes.Add(make);

            var user = new ApplicationUser()
            {
                Email = "user@abv.bg",
                PasswordHash = "password",
                UserName = "user",
                ProfilePhotoUrl = "profile-url",
                CoverPhotoUrl = "cover-url",
            };

            this.DbContext.Users.Add(user);
            this.DbContext.SaveChanges();

            var userId = this.DbContext.Users.Select(u => u.Id).First();

            var post = new Post()
            {
                Description = "description",
                UserId = userId,
            };

            this.DbContext.Posts.Add(post);

            var makeId = this.DbContext.Makes.Select(m => m.Id).First();

            var car = new Car()
            {
                Horsepower = 150,
                TopSpeed = 230,
                MainImageUrl = "main Image",
                MakeId = makeId,
                Model = "M5",
                Year = 2008,
            };

            this.DbContext.SaveChanges();
        }
    }
}
