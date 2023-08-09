namespace TechShop.Services.Data.Models.User
{
    using TechShop.Web.ViewModels.User;

    public class AllUsersFilteredServiceModel
    {
        public AllUsersFilteredServiceModel()
        {
            Users = new HashSet<UserViewModel>();
        }
        public int TotalUsersCount { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
