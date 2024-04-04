using System;
using ContactListApp.BAL.Interfaces;
using ContactListApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace ContactListApp.DAL.Repositories
{
	public class ContactRepository : IContactRepository
    {
		private readonly AppDbContext _dbContaxt;
		public ContactRepository(AppDbContext dbContaxt)
		{
			_dbContaxt = dbContaxt;
		}

		public async Task<List<Contact>> GetAllContactAsync()
		{
			return await _dbContaxt.Contacts.Include(x=>x.Addresses).ToListAsync();
		}

        public async Task<Contact?> GetContactById(Guid Id)
        {
            return await _dbContaxt.Contacts.Include(x => x.Addresses).FirstOrDefaultAsync(x=>x.Id == Id);
        }

        public async Task AddContactAsync(Contact contact)
        {
			await _dbContaxt.Contacts.AddAsync(contact);

            if (contact.Addresses != null)
            {
                await _dbContaxt.Addresses.AddRangeAsync(contact.Addresses);
            }

			await _dbContaxt.SaveChangesAsync();
        }

        public async Task UpdateContactAsync(Contact contact)
        {
			_dbContaxt.Entry(contact).State = EntityState.Modified;

            if (contact.Addresses != null)
            {
                await _dbContaxt.Addresses.AddRangeAsync(contact.Addresses);
            }

            await _dbContaxt.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(Guid id)
        {
            var contact=await _dbContaxt.Contacts.FindAsync(id);
            if (contact != null)
            {
                _dbContaxt.Contacts.Remove(contact);
                await _dbContaxt.SaveChangesAsync();
            }
        }

        public async Task RemoveAllContactAddress(Guid Id)
        {
            var addresses= _dbContaxt.Addresses.Where(x => x.ContactId == Id);
            _dbContaxt.Addresses.RemoveRange(addresses);
            await _dbContaxt.SaveChangesAsync();
        }
    }
}

