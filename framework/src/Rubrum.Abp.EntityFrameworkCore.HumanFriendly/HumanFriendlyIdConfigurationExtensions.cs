﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rubrum.Abp.Ddd.HumanFriendly;

namespace Rubrum.Abp.EntityFrameworkCore.HumanFriendly;

public static class HumanFriendlyIdConfigurationExtensions
{
    public static void ConfigureByHumanFriendlyId<T>(this EntityTypeBuilder builder)
    {
        if (builder.Metadata.ClrType.IsAssignableTo<IHumanFriendlyId>())
        {
            builder.Property(nameof(IHumanFriendlyId.HumanFriendlyId))
                .ValueGeneratedOnAdd()
                .IsRequired();
        }
    }
}