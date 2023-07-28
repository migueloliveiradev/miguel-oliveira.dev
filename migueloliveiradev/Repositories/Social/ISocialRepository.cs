using migueloliveiradev.Models.Network;

namespace migueloliveiradev.Repositories.Social
{
    public interface ISocialRepository
    {
        IEnumerable<RedeSocial> GetSocials();
        RedeSocial GetSocial(int id);
        void CreateSocial(RedeSocial rede);
        void UpdateSocial(RedeSocial rede);
        void DeleteSocial(int id);
    }
}
