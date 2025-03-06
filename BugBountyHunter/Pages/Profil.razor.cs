using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BugBountyHunter.Pages
{
    [Authorize]
    public partial class Profil
    {
        List<string> Infos { get; set; }

        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Infos = new List<string>();
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            foreach (var claim in user.Claims)
            {
                Infos.Add($"{claim.Subject.Name} - {claim.Type} - {claim.Value}");
            }
        }
    }
}
