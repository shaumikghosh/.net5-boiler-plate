using DataModel.ViewModels;
using System.Threading.Tasks;

namespace WebProject.Areas.User.Interfaces {
    public interface IProfileSettings {
        Task<dynamic> ChnagePassword(ChangePassword change, string userId);
        Task<dynamic> ChangeEmail(ChangeEmail email, string userId);
        Task<dynamic> ChangeProfileDetails(ChangeProfileDetails changeProfileDetails, string id);
    }
}
