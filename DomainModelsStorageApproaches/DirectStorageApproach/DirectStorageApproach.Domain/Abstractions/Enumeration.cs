using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DirectStorageApproach.Domain.Abstractions;

public abstract record Enumeration<TEnum>(int Id, string Name)
    where TEnum : Enumeration<TEnum>
{
    public static IEnumerable<TEnum> GetAll()
    {
        var enumerationType = typeof(TEnum);

        var result = enumerationType
            .GetProperties(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy)
            .Where(propertyInfo =>
                enumerationType.IsAssignableFrom(propertyInfo.PropertyType))
            .Select(propertyInfo =>
                (TEnum)propertyInfo.GetValue(default))
            .ToArray();

        return result;
    }

    public static TEnum GetByName(string name)
    {
        var status = GetAll()
            .FirstOrDefault(status => string.Equals(status.Name, name));

        return status;
    }

    public static TEnum GetById(int id)
    {
        var status = GetAll()
            .FirstOrDefault(status => status.Id == id);

        return status;
    }
}
