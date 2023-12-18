using System.Diagnostics.CodeAnalysis;

namespace Lisit.Models.Base;

[ExcludeFromCodeCoverage]
public abstract class NamedObject : IdentificableObject
{
    public string Nombre { get; set; }
}