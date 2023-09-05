using System.ComponentModel.DataAnnotations.Schema;

namespace migueloliveiradev.Models.Works.Projetos;

public class ProjectTechnology
{
    public int Id { get; set; }
    [ForeignKey("Project")]
    public int ProjectId { get; set; }
    public virtual Project Project { get; set; }
    [ForeignKey("Technology")]
    public int TechnologyId { get; set; }
    public virtual Technology Technology { get; set; }
}
