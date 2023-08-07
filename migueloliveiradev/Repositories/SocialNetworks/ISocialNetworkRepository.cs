using migueloliveiradev.Models.Network;

namespace migueloliveiradev.Repositories.SocialNetworks;

public interface ISocialNetworkRepository
{
    SocialNetwork? GetById(int id);
    IEnumerable<SocialNetwork> GetAll();
    int GetCount();
    void Create(SocialNetwork rede);
    void Update(SocialNetwork rede);
    void Delete(int id);
}
