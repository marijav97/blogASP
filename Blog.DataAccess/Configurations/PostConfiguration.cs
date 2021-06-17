using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.EfDataAccess.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.Description)
                   .IsRequired();

            builder.HasMany(x => x.Comments)
                    .WithOne(c => c.Post)
                    .HasForeignKey(x => x.PostId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Votes)
                   .WithOne(v => v.Post)
                   .HasForeignKey(v => v.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.PostTags)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
