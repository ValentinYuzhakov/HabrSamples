using System;
using AutoMapper;

namespace MappingToDbEntitiesApproach.Infrastructure.Mapping.Converters;

public sealed class LongToTimeSpanConverter : ITypeConverter<long?, TimeSpan?>
{
    public TimeSpan? Convert(long? source, TimeSpan? destination, ResolutionContext context)
    {
        return source.HasValue ? TimeSpan.FromSeconds(source.Value) : null;
    }
}
