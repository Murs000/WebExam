using System.ComponentModel.DataAnnotations;

namespace WebExam.Entity.Interfaces
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
