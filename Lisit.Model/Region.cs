using System.Diagnostics.CodeAnalysis;
using Lisit.Models.Base;

namespace Lisit.Models {
    [ExcludeFromCodeCoverage]
    public class Region : NamedObject {
        public int PaisId { set; get; }
    }
}