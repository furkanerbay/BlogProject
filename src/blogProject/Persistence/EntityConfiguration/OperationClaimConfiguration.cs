﻿using Core.Security.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Constants.OperationClaims;

namespace Persistence.EntityConfiguration;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(o => o.Id);
        builder.Property(o => o.Id).HasColumnName("Id");
        builder.Property(o => o.Name).HasColumnName("Name");
        builder.HasIndex(indexExpression: o => o.Name, name: "UK_OperationClaims_Name").IsUnique();

        int id = 1;
        HashSet<OperationClaim> operationClaimSeeds = new();

        #region OperationClaimSeedItems

        operationClaimSeeds.Add(new OperationClaim { Id = id++, Name = Admin });

        //TODO: add feature operation claim seeds

        #endregion

        builder.HasData(operationClaimSeeds);
    }
}
