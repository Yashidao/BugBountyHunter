using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BugBountyHunter.Layout
{
    public partial class NavMenu
    {
        [Inject]
        NavigationManager NavigationManager { get; set; }
        private void LoginWithAzure()
        {
            NavigationManager.NavigateTo("authentication/login");
        }
        private void LogoutWithAzure()
        {
            NavigationManager.NavigateToLogout("authentication/logout");
        }
    }
}
