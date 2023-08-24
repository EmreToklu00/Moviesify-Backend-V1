using Core.Utilities.Results;
using Entity.DTO;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMovieService
    {
        IDataResult<MovieDTO> GetById(Guid movieId);

        IDataResult<List<MovieDTO>> GetList();

        IDataResult<List<MovieDTO>> GetListByCategory(Guid categoryId);
        IResult Add(MovieDTO movie);

        IResult Update(MovieDTO movie);

        IResult Delete(Guid movieId);
    }
}
