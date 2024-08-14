using Contacts_Application.Views;

namespace Contacts_Application
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            InitializeComponent();
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainContactPage), typeof(MainContactPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
            Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
        }
    }
}
