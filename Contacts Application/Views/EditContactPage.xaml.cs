using Contacts_Application.Models;

namespace Contacts_Application.Views;


[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
	private Models.Contact contact;

	public EditContactPage()
	{
		InitializeComponent();
	}

	public	string ContactId
	{
		set
		{
			contact = ContactRepository.GetContactById(int.Parse(value));
		}
}