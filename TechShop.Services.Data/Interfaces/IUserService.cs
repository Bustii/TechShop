namespace TechShop.Services.Data.Interfaces
{
    using TechShop.Services.Data.Models.User;
    using TechShop.Web.ViewModels.User;

    public interface IUserService
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();

        Task<IEnumerable<UserViewModel>> GetAllUsersExceptCurrentOneAsync(string userId);

        Task<AllUsersFilteredServiceModel> AllUsersQueryAsync(AllUsersQueryModel queryModel);

        Task<EditUserProfileViewModel> GetUserByIdAsync(string userId);

        Task EditProfileAsync(string userId, EditUserProfileViewModel model);

        Task SoftDeleteUserAsync(string userId);

        Task ReverseIsAdministratorAsync(string userId);

        Task<bool> UserExistsByIdAsync(string userId);
    }
}
