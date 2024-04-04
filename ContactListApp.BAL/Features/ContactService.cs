using System;
using ContactListApp.BAL.Features.Interfaces;
using ContactListApp.BAL.Interfaces;
using ContactListApp.Shared;

namespace ContactListApp.BAL.Features
{
	public class ContactService : IContactService
    {
		private readonly IContactRepository _contactRepository;
		public ContactService(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}


        public async Task<List<Contact>> GetAllContactAsync()
        {
            return await _contactRepository.GetAllContactAsync();
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            contact.Id = Guid.NewGuid();

            UpdateAddressIds(contact);

            await _contactRepository.AddContactAsync(contact);
            return contact;
        }

        private void UpdateAddressIds(Contact contact)
        {
            if (contact.Addresses != null)
            {
                foreach (var address in contact.Addresses)
                {
                    if (address.Id == Guid.Empty)
                    {
                        address.Id = Guid.NewGuid();
                    }
                }
            }
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            await _contactRepository.RemoveAllContactAddress(contact.Id);

            UpdateAddressIds(contact);

            await _contactRepository.UpdateContactAsync(contact);
        }

        public async Task DeleteContactAsync(Guid id)
        {
            await _contactRepository.DeleteContactAsync(id);
        }

        public async Task<Contact?> GetContactById(Guid Id)
        {
            return await _contactRepository.GetContactById(Id);
        }
    }
}

