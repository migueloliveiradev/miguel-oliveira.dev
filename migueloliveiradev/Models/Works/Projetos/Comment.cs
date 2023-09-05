using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace migueloliveiradev.Models.Works.Projetos;

public class Comment
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    [DefaultValue(CommentStatus.Pending)]
    public CommentStatus Status { get; set; }
    [ForeignKey("Project")]
    public int ProjectId { get; set; }

    public virtual Project Project { get; set; }
}

public enum CommentStatus
{
    Pending,
    Approved,
    Rejected
}