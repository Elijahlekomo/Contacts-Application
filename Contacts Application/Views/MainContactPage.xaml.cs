using Contacts_Application.Models;
using System.Collections.ObjectModel;

namespace Contacts_Application.Views;

public partial class MainContactPage : ContentPage
{
	public MainContactPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadContacts();
    }


    private void LoadContacts()
	{
		var results = new ObservableCollection<Models.Contact>(ContactRepository.GetAllContacts());
		xmlContactList.ItemsSource = results;
	}

    private async void xmlContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (xmlContactList.SelectedItem != null)
		{
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Models.Contact)xmlContactList.SelectedItem).Id}");
		}
    }

    private void xmlContactList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		xmlContactList.SelectedItem = null;
    }

    private void BtnAddContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }
}