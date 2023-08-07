namespace migueloliveiradev.Models.Works.Projetos;

public class Project
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string SubTitulo { get; set; }
    public string Descricao { get; set; }
    public string? Url { get; set; }
    public string? UrlGithub { get; set; }
    public string? UrlLinkedin { get; set; }
    public bool Working { get; set; }
    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }
    public virtual List<Image> Images { get; set; }
    public virtual List<Technology> Technologies { get; set; }
}
