using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Me;

namespace migueloliveiradev.Repositories.Contacts;

public class ContactRepository : IContactRepository
{
    private readonly DatabaseContext context;

    public ContactRepository(DatabaseContext context)
    {
        this.context = context;
    }

    public Contact GetById(int id)
    {
        return context.Contacts.Find(id);
    }

    public IEnumerable<Contact> GetAll()
    {
        return context.Contacts.ToList();
    }

    public IEnumerable<Contact> GetAllUnread()
    {
        return context.Contacts.Where(c => c.Status == Status.Unread).ToList();
    }

    public IEnumerable<Contact> GetAllRead()
    {
        return context.Contacts.Where(c => c.Status == Status.Read).ToList();
    }

    public IEnumerable<Contact> GetAllAnswered()
    {
        return context.Contacts.Where(c => c.Status == Status.Answered).ToList();
    }

    public IEnumerable<Contact> GetAllDiscarded()
    {
        return context.Contacts.Where(c => c.Status == Status.Discarded).ToList();
    }

    public int GetCount()
    {
        return context.Contacts.Count();
    }

    public int GetCountUnread()
    {
        return context.Contacts.Where(c => c.Status == Status.Unread).Count();
    }

    public void Create(Contact contact)
    {
        context.Contacts.Add(contact);
        context.SaveChanges();
    }

    public void Update(Contact contact)
    {
        context.Contacts.Update(contact);
        context.SaveChanges();
    }
    public void MaskAsRead(int id)
    {
        context.Contacts.Where(p => p.Id == id).ExecuteUpdate(c => c.SetProperty(p => p.Status, Status.Read));
    }
    public void MaskAsAnswered(int id)
    {
        context.Contacts.Where(p => p.Id == id).ExecuteUpdate(c => c.SetProperty(p => p.Status, Status.Answered));
    }

    public void Delete(int id)
    {
        context.Contacts.Where(p => p.Id == id).ExecuteDelete();
    }
}
