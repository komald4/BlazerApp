using System;
using ContactListApp.Shared;

namespace ContactListApp.BAL.Features.Interfaces
{
	public interface IContactService
	{
        Task<List<Contact>> GetAllContactAsync();
        Task<Contact?> GetContactById(Guid id);
        Task<Contact> AddContactAsync(Contact contact);
        Task UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Guid id);
    }
}

