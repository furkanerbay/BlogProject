using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfiguration;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs").HasKey(b => b.Id);
        builder.Property(b => b.Id).HasColumnName("Id");
        builder.Property(b => b.CategoryId).HasColumnName("CategoryId");
        builder.Property(b => b.Title).HasColumnName("Title");
        builder.Property(b => b.Body).HasColumnName("Body");
        builder.Property(b => b.ApplicationUserId).HasColumnName("ApplicationUserId");
        builder.HasOne(b => b.Category);
        builder.HasOne(b => b.ApplicationUser);//.WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(b => b.Comments);
        builder.HasMany(b => b.Likes);
    }
}
