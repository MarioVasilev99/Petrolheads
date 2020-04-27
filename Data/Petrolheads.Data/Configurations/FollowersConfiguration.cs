namespace Petrolheads.Data.Configurations
{
    using System;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Petrolheads.Data.Models;

    public class FollowersConfiguration : IEntityTypeConfiguration<Follower>
    {
        public void Configure(EntityTypeBuilder<Follower> builder)
        {
            builder
                .HasOne(m => m.User)
                .WithMany(m => m.Followers)
                .HasForeignKey(k => k.UserId);

            builder
                .HasOne(m => m.FollowedBy)
                .WithMany(m => m.Following)
                .HasForeignKey(k => k.FollowedById);
        }
    }
}
