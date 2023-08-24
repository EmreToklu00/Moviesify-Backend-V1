using Business.Abstract;
using Business.Constants.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.Models;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(CategoryDTO category)
        {
            Category entity = new Category()
            {
                CategoryId = category.CategoryId,
                Name = category.Name,
                Description = category.Description,
            };
            _categoryDal.Add(entity);
            return new SuccessResult(message: ResultMessages.CATEGORY_ADDED);
        }

        public IResult Delete(Guid categoryId)
        {
            Category entity = _categoryDal.Get(m => m.CategoryId == categoryId);
            _categoryDal.Delete(entity);
            return new SuccessResult(message: ResultMessages.CATEGORY_DELETED);
        }

        public IDataResult<CategoryDTO> GetById(Guid categoryId)
        {
            Category entity = _categoryDal.Get(m => m.CategoryId == categoryId);
            CategoryDTO response = new CategoryDTO()
            {
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                Description = entity.Description,
            };
            return new SuccessDataResult<CategoryDTO>(response);
        }

        public IDataResult<List<CategoryDTO>> GetList()
        {
            List<Category> entityList = _categoryDal.GetAll().ToList();
            List<CategoryDTO> responseList = new List<CategoryDTO>();
            foreach (var category in entityList)
            {
                var movieDTO = new CategoryDTO()
                {
                    CategoryId = category.CategoryId,
                    Name= category.Name,
                    Description = category.Description,
                };
                responseList.Add(movieDTO);
            }
            return new SuccessDataResult<List<CategoryDTO>>(responseList);
        }

        public IResult Update(CategoryDTO category)
        {
            Category entity = _categoryDal.Get(m => m.CategoryId == category.CategoryId);
            entity.Name = category.Name;
            entity.Description = category.Description;
            _categoryDal.Update(entity);
            return new SuccessResult(message: ResultMessages.CATEGORY_UPDATED);
        }

        
    }
}
