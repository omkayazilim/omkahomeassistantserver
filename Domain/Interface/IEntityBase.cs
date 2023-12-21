
namespace Domain.Interface
{
    public interface IEntitiesBase
    {
        long Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
        string CreatedUser { get; set; }
        string UpdatedUser { get; set; }
        bool IsActive { get; set; }
    }
}
