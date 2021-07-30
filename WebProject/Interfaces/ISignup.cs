using DataModel.ViewModels;
using System.Threading.Tasks;

namespace WebProject.Interfaces {
    public interface ISignup {
        Task<string> SignUp(SignupModel signup);
    }
}
