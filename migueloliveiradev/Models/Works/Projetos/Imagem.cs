namespace migueloliveiradev.Models.Works.Projetos;

public class Imagem
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Url { get; set; }
    public Projeto Projeto { get; set; }
}
