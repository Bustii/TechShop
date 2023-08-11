namespace TechShop.Web.ViewModels.User
{
    using TechShop.Web.ViewModels.User;
    using TechShop.Web.ViewModels.User.Enums;
    using System.ComponentModel.DataAnnotations;

    using static TechShop.Common.GeneralApplicationConstans;
    public class AllUsersQueryModel
    {
        public AllUsersQueryModel()
        {
            CurrentPage = DefaultPage;
            UsersPerPage = EntitiesPerPage;

            Users = new HashSet<UserViewModel>();
        }

        [Display(Name = "Search by word")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort Products By")]
        public UsersSorting ItemSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Users On Page")]
        public int UsersPerPage { get; set; }

        public int TotalUsers { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
