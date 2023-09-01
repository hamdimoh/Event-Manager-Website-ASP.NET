using Microsoft.AspNetCore.Mvc.Rendering;
using Organisationstool.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cart
{
    public List<Product> Products { get; set; }

    [NotMapped]
    public int VeranstaltungId { get; set; }

    [NotMapped]
    public List<SelectListItem> VeranstaltungenListItems { get; set; }

    [NotMapped]
    public double? Budget { get; set; }

    public Cart()
    {
        Products = new List<Product>();
    }

    [Key]
    public int CartId { get; set; }

}

