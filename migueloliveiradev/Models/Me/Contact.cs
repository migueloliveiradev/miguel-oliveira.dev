using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace migueloliveiradev.Models.Me;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    [DefaultValue(Status.Unread)]
    public Status Status { get; set; }
    public DateTime SendDate { get; set; }

}
public enum Status
{
    [Display(Name = "Não lidos")]
    Unread,
    [Display(Name = "Lidos")]
    Read,
    [Display(Name = "Respondidos")]
    Answered,
    [Display(Name = "Descartados")]
    Discarded
}
