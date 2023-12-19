using System.Diagnostics.CodeAnalysis;
using Lisit.Models.Base;

namespace Lisit.Models.Localizacion;
[ExcludeFromCodeCoverage]
public class Comuna : NamedObject {
    public int RegionId { set; get; }
}
