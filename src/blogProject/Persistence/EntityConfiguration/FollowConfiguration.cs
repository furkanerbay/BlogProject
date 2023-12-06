using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfiguration;

public class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        builder.ToTable("Follows").HasKey(f => f.Id);
        builder.Property(f => f.Id).HasColumnName("Id");
        builder.Property(f => f.ApplicationUserId).HasColumnName("ApplicationUserId");
        builder.Property(f => f.ApplicationUserIdFollowedId).HasColumnName("ApplicationUserIdFollowedId");
        builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate");
        builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");
        builder.HasOne(f => f.ApplicationUser);
        builder.HasOne(f => f.ApplicationUserIdFollowed);
    }
}