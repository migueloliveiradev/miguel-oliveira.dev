using migueloliveiradev.Models.Works;

namespace migueloliveiradev.Repositories.Works.Skills
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetSkills();
        Skill GetSkill(int id);
        void CreateSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
    }
}
