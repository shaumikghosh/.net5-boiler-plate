using DataModel.ViewModels;
using System.Threading.Tasks;

namespace WebProject.Interfaces {
    public interface ILogin {
        Task<string> LogIn(LoginModel loginModel);
    }
}
