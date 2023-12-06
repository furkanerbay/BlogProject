using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfiguration;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("Likes");
        builder.Property(l => l.Id).HasColumnName("Id");
        builder.Property(l => l.ApplicationUserId).HasColumnName("ApplicationUserId");
        builder.Property(l => l.BlogId).HasColumnName("BlogId");
        builder.HasOne(l => l.ApplicationUser);
        builder.HasOne(l => l.Blog);

        //Like[] likeSeeds =
        //{
        //    new(id:1,likeUserId:1,blogId:1),
        //    new(id:2,likeUserId:1,blogId:2)
        //};
    }
}