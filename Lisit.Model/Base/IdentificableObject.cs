using System.Diagnostics.CodeAnalysis;

namespace Lisit.Models.Base;

[ExcludeFromCodeCoverage]
public abstract class IdentificableObject
{
    public int Id { get; set; }
}
