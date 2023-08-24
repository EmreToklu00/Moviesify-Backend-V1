using Core.Entities;

namespace Entity.DTO
{
    public class CategoryDTO : IEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
