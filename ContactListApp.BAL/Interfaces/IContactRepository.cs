using System;
using ContactListApp.Shared;

namespace ContactListApp.BAL.Interfaces
{
	public interface IContactRepository
	{
        Task<List<Contact>> GetAllContactAsync();
        Task<Contact?> GetContactById(Guid Id);
        Task AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Guid id);
        Task RemoveAllContactAddress(Guid Id);
    }
}

