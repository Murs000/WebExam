using System.ComponentModel.DataAnnotations;

namespace WebExam.Infrasrtucture.Interfaces
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
