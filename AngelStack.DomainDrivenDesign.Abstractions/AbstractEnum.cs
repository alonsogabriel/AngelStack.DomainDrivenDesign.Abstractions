namespace AngelStack.DomainDrivenDesign.Abstractions;

public abstract record AbstractEnum<T>(int Value, string Name)
    where T : AbstractEnum<T>
{
    public static T FromValue(int value)
    {
        return GetValues().FirstOrDefault(e => e.Value == value) ??
            throw new ArgumentOutOfRangeException(nameof(value),
                $"Invalid value '{value}' in enum '{typeof(T).Name}'.");
    }

    public static T FromName(string name)
    {
        return GetValues().FirstOrDefault(e => e.Name == name) ??
            throw new ArgumentOutOfRangeException(nameof(name),
                $"Invalid name '{name}' in enum '{typeof(T).Name}'.");
    }

    public static IEnumerable<T> GetValues()
    {
        var type = typeof(T);

        return type.GetFields()
            .Where(f => f.IsPublic && f.IsStatic && f.IsInitOnly && f.FieldType == type)
            .Select(f => f.GetValue(null))
            .Cast<T>();
    }
}
