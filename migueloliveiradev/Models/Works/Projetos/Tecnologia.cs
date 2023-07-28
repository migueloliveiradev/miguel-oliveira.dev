namespace migueloliveiradev.Models.Works.Projetos;

public class Tecnologia
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Imagem Logo { get; set; }
    public string Url { get; set; }
    public List<Projeto> Projetos { get; set; }
}
