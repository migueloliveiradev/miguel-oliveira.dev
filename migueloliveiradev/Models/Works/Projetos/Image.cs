using System.ComponentModel.DataAnnotations.Schema;

namespace migueloliveiradev.Models.Works.Projetos;

public class Image
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    [NotMapped]
    public string Url => $"{Environment.GetEnvironmentVariable("SITE_URL_IMAGES")}/{Name}";
    [ForeignKey("Projeto")]
    public int ProjetoId { get; set; }

    public virtual Project Projeto { get; set; }
}
