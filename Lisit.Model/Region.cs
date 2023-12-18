using Lisit.Models.Base;
using System.Diagnostics.CodeAnalysis;

namespace Lisit.Model
{
    [ExcludeFromCodeCoverage]
    public class Region : NamedObject
    {
        public int PaisId { set; get; }
    }
}