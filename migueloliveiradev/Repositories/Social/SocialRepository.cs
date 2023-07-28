using Microsoft.EntityFrameworkCore;
using migueloliveiradev.Database;
using migueloliveiradev.Models.Network;

namespace migueloliveiradev.Repositories.Social
{
    public class SocialRepository : ISocialRepository
    {
        private readonly DatabaseContext context;
        public SocialRepository(DatabaseContext context)
        {
            this.context = context;
        }
        public void CreateSocial(RedeSocial rede)
        {
            context.RedeSociais.Add(rede);
            context.SaveChanges();
        }

        public void DeleteSocial(int id)
        {
            context.RedeSociais.Where(p => p.Id == id).ExecuteDelete();
        }

        public RedeSocial? GetSocial(int id)
        {
            return context.RedeSociais.Find(id);
        }

        public IEnumerable<RedeSocial> GetSocials()
        {
            return context.RedeSociais.AsNoTracking().ToList();
        }

        public void UpdateSocial(RedeSocial rede)
        {
            context.RedeSociais.Update(rede);
            context.SaveChanges();
        }
    }
}