using Core.Utilities.Results;
using Entity.DTO;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<CategoryDTO> GetById(Guid categoryId);

        IDataResult<List<CategoryDTO>> GetList();

        IResult Add(CategoryDTO category);

        IResult Update(CategoryDTO category);

        IResult Delete(Guid categoryId);
    }
}
