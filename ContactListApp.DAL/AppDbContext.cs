using ContactListApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace ContactListApp.DAL;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>()
            .HasOne(x => x.Contact)
            .WithMany(x => x.Addresses)
            .HasForeignKey(x => x.ContactId);

        this.SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var contact1Id = Guid.NewGuid();
        var contact1 = new Contact()
        {
            Id= contact1Id,
            FirstName="Mónica",
            LastName= "Gallego",
                   };

        var contact1Add = new Address()
        {
            Id = Guid.NewGuid(),
            City = "Bilbao",
            State = "Islas Baleares",
            Street = "Calle de Tetuán",
            ZipCode = "34518",
            ContactId = contact1Id
        };

        //contact 2
        var contact2Id = Guid.NewGuid();
        var contact2 = new Contact()
        {
            Id = contact2Id,
            FirstName = "",
            LastName = "",
         };

        var contactAdd2 = new Address()
        {
            Id = Guid.NewGuid(),
            City = "Henry",
            State = "James",
            Street = "Calle de Tetuán",
            ZipCode = "34518",
            ContactId = contact2Id
        };

        //contact 3
        var contact3Id = Guid.NewGuid();
        var contact3 = new Contact()
        {
            Id = contact3Id,
            FirstName = "",
            LastName = "",
            
        };

        var contact3Add = new Address()
        {
            Id = Guid.NewGuid(),
            City = "Bilbao",
            State = "Islas Baleares",
            Street = "Calle de Tetuán",
            ZipCode = "34518",
            ContactId = contact3Id
        };

        //contact 4
        var contact4Id = Guid.NewGuid();
        var contact4 = new Contact()
        {
            Id = contact4Id,
            FirstName = "",
            LastName = "",
            
        };

        var contact4Add = new List<Address>()
            {
                new Address()
                {
                    Id=Guid.NewGuid(),
                        City="Bilbao",
                    State="Islas Baleares",
                    Street="Calle de Tetuán",
                    ZipCode="34518",
                    ContactId=contact4Id
                },
                new Address()
                {
                    Id=Guid.NewGuid(),
                        City="Bilbao",
                    State="Islas Baleares",
                    Street="Calle de Tetuán",
                    ZipCode="34518",
                    ContactId=contact4Id
                }
            };

        modelBuilder.Entity<Contact>().HasData(contact1, contact2, contact3, contact4);

        modelBuilder.Entity<Address>().HasData(contact1Add, contactAdd2, contact3Add, contact4Add[0], contact4Add[1]);
    }
}

