using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Organisationstool.Models.ViewModels
{
    public class MitwirkenderVM
    {
        public Mitwirkende Mitwirkende { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VeranstaltungList { get; set; }
    }
}
