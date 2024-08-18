using Contacts_Application.Models;

namespace Contacts_Application.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

    private void ContactCtrl_OnSave(object sender, EventArgs e)
    {
		var newContact = new Models.Contact()
		{
			Name = ContactCtrl.Name,
			Email = ContactCtrl.Email,
			PhoneNumber = ContactCtrl.PhoneNumber

		};

		ContactRepository.AddContact(newContact);
    }
}