using Domain.Interface;

namespace Domain.Entities
{
    public class EntityBase : IEntitiesBase
    {
        public EntityBase()
        {
            CreatedDate = DateTime.Now;
            CreatedUser = "SYS";
            IsActive = true;
        }
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string UpdatedUser { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
