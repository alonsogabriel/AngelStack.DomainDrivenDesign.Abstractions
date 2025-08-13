namespace DomainDrivenDesign.Abstractions.ValueObjects;

public enum ImageType
{
    Unknown,
    Jpeg,
    Png,
    Svg,
    Webp,
    Bmp,
}

public record Image(string Url, ImageType Type, long Size, string Name, byte[]? Content)
{
}