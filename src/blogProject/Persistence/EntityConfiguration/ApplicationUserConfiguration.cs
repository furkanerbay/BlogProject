using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfiguration;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers").HasKey(b => b.Id);
        builder.Property(c => c.Id).HasColumnName("Id");
        builder.Property(c => c.UserId).HasColumnName("UserId");
        builder.HasIndex(indexExpression: c => c.UserId, name: "UK_Customers_UserId").IsUnique();
        builder.HasOne(b => b.User);
        builder.HasMany(b => b.Likes);
        builder.HasMany(b => b.Comments);
        builder.HasMany(b => b.Blogs);
    }
}
