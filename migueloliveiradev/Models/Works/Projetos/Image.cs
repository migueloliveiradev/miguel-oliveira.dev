namespace migueloliveiradev.Models.Works.Projetos;

public class Image
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Url { get; set; }
    public virtual Project Projeto { get; set; }
}
