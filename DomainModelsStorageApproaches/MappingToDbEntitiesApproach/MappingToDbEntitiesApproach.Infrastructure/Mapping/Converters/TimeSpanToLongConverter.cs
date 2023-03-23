using System;
using AutoMapper;

namespace MappingToDbEntitiesApproach.Infrastructure.Mapping.Converters;

public sealed class TimeSpanToLongConverter : ITypeConverter<TimeSpan?, long?>
{
    public long? Convert(TimeSpan? source, long? destination, ResolutionContext context)
    {
        return source.HasValue ? (long)source.Value.TotalSeconds : null;
    }
}
