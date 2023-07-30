using migueloliveiradev.Models.Me;

namespace migueloliveiradev.Repositories.Contacts;

public interface IContactRepository
{
    Contact GetById(int id);
    IEnumerable<Contact> GetAll();
    IEnumerable<Contact> GetAllUnread();
    IEnumerable<Contact> GetAllRead();
    IEnumerable<Contact> GetAllAnswered();
    IEnumerable<Contact> GetAllDiscarded();
    int GetCount();
    int GetCountUnread();
    void Create(Contact contact);
    void Update(Contact contact);
    void MaskAsRead(int id);
    void MaskAsAnswered(int id);
    void Delete(int id);
}
