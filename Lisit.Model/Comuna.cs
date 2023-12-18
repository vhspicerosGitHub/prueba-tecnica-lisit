using Lisit.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace Lisit.Model
{
    [ExcludeFromCodeCoverage]
    public class Comuna : NamedObject
    {
        public int RegionId { set; get; }
    }
}