using migueloliveiradev.Models.Works.Projetos;
using System.ComponentModel.DataAnnotations.Schema;

namespace migueloliveiradev.Models.Works;

public class Technology
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public TypeIcon TypeIcon { get; set; }
    public string Icon { get; set; }
    [NotMapped]
    public string? IconUrl => $"{Environment.GetEnvironmentVariable("SITE_URL_IMAGES")}/{Icon}";
    public string Url { get; set; }
    public virtual List<Project> Projects { get; set; }
}
public enum TypeIcon
{
    FontAwesome,
    File
}