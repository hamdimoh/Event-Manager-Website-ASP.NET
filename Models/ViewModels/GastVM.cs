using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Organisationstool.Models.ViewModels
{
    public class GastVM
    {
        public Gast Gast { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VeranstaltungList { get; set; }
    }
}
