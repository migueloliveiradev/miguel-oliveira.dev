using System.ComponentModel.DataAnnotations.Schema;

namespace migueloliveiradev.Models.Works.Projetos;

public class Image
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Url { get ; set; }
    [NotMapped]
    public string UrlCompleta => $"{Environment.GetEnvironmentVariable("SITE_URL_IMAGES")}/{Url}";
    [ForeignKey("Projeto")]
    public int ProjetoId { get; set; }

    public virtual Project Projeto { get; set; }
}
