using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfiguration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);
        builder.Property(c => c.Id).HasColumnName("Id");
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.HasIndex(indexExpression: c => c.Name, name: "UK_Categories_Name").IsUnique();
        builder.HasMany(c => c.Blogs);

        Category[] categorySeeds = { new(id: 1, name: "Yazılım"), new(id: 2, name: "Teknoloji") };
        builder.HasData(categorySeeds);
    }
}
