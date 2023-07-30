using migueloliveiradev.Models.Works.Projetos;

namespace migueloliveiradev.Models.Works;

public class Technology
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public TypeIcon TypeIcon { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
    public virtual List<Project> Projetos { get; set; }
}
public enum TypeIcon
{
    Svg,
    FontAwesome,
}