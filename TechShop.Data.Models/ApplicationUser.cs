namespace TechShop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.BuyedProducts = new HashSet<Product>();
        }

        public virtual ICollection<Product> BuyedProducts { get; set; }
    }
}
