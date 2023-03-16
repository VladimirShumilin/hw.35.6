namespace AwesomeNetwork.ViewModels
{
    public class HomeViewModel
    {
        public RegisterViewModel RegisterView { get; set; } = new RegisterViewModel();

        public LoginViewModel LoginView { get; set; } = new LoginViewModel();

        public HomeViewModel()
        {

        }
    }
}
