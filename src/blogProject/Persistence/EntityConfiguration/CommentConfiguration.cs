using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfiguration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.Property(l => l.Id).HasColumnName("Id");
        builder.Property(l => l.BlogId).HasColumnName("BlogId");
        builder.Property(l => l.ApplicationUserId).HasColumnName("ApplicationUserId");
        builder.Property(l => l.CommentMessage).HasColumnName("Message");
        //builder.HasOne(l => l.Blog).WithMany(b=>b.Comments).OnDelete(DeleteBehavior.ClientNoAction);
        builder.HasOne(l => l.Blog);
        builder.HasOne(l => l.ApplicationUser);
    }
}
