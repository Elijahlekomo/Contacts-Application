using Contacts_Application.Views;
using Microsoft.Maui.ApplicationModel.Communication;

namespace Contacts_Application.Models
{
    public class ContactRepository
    {
        public static List<Contact> contactList = new List<Contact>()
        {
            new Contact() {Id = 1, Name="David bennard", Email="David@gmail.com", PhoneNumber=1234567},
            new Contact() {Id = 2, Name="Rebacca Smith", Email="Rebacca @gmail.com", PhoneNumber=12345636},
            new Contact() {Id = 3, Name="Tobe Jones", Email="Tobe@gmail.com", PhoneNumber=345678965},
            new Contact() {Id = 4, Name="Daniela Fish", Email="Daniela@gmail.com", PhoneNumber=567891234},
            new Contact() {Id = 5, Name="Koops kuni", Email="Koops@gmail.com", PhoneNumber=789123456},
            new Contact() {Id = 6, Name="Savour Dave", Email="Savour@gmail.com", PhoneNumber=167892345},
            new Contact() {Id = 7, Name="Favour", Email="Favour@gmail.com", PhoneNumber=891234567},
            new Contact() {Id = 8, Name="Chris Sevens", Email="Chris@gmail.com", PhoneNumber=234567891},
            new Contact() {Id = 9, Name="Kuiso Kabongo", Email="Kuiso@gmail.com", PhoneNumber=456789123},
            new Contact() {Id = 10, Name="James Doe", Email="James@gmail.com", PhoneNumber=134526789},
        };
        //CRUD(Create, Read, Update, Delete)

        //Create
        public static void AddContact(Contact contact)
        {
            if (contact != null)
            {
                var checkEmail = contactList.FirstOrDefault(x => x.Email.Equals(contact.Email));
                if (contact == null)
                {
                    Shell.Current.DisplayAlert("Error", "Contact already Added", "Ok");
                    return;
                }
                int maxId = contactList.Max(x => x.Id);
                contact.Id = maxId;
                contactList.Add(contact);
                Shell.Current.DisplayAlert("Success", "Contact Added Done", "Ok");
                //Absolute path
                Shell.Current.GoToAsync($"{nameof(MainContactPage)}");


            }
        }
        //Get (Read 1)
        public static List<Contact> GetAllContacts() => contactList;
        //Read (Read 2)
        public static List<Contact> GetContactById(int id)
        {
            var result = contactList.FirstOrDefault(x => x.Id == id);
            return result;
        }
        //Update
        public static void UpdateContact(Contact contact)
        {
            var result = contactList.FirstOrDefault(x => x.Id == contact.Id);
            if (result != null)
            {
                result.Name = contact.Name;
                result.Email = contact.Email;
                result.PhoneNumber = contact.PhoneNumber;
                Shell.Current.DisplayAlert("Success", "Contact Updated Done", "Ok");
                Shell.Current.GoToAsync("..");
            }
        }

        public static void DeleteContact(int id)
        {
            var result = contactList.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                contactList.Remove(result);
                Shell.Current.DisplayAlert("Success", "Contact Deleted Done", "Ok");
            }
        }

        //Search 
        public static List<Contact> Searchcontacts(string filter)
        {
            var contacts = contactList.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.ToLower().Contains(filter.ToLower())).ToList();
            if(contacts == null ||  contacts.Count <= 0)
                contacts = contactList.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.ToLower().Contains(filter.ToLower())).ToList();               
            else return contacts;

            if (contacts == null || contacts.Count <= 0)
                contacts = contactList.Where(x => x.PhoneNumber == int.Parse(filter)).ToList();
            else return contacts;

            return contacts;
        }
    }
}