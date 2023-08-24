using Business.Abstract;
using Business.Constants.Results;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.DTO;
using Entity.Models;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class MovieManager : IMovieService
    {

        IMovieDal _movieDal;

        public MovieManager(IMovieDal movieDal)
        {
            _movieDal = movieDal;
        }

        public IResult Add(MovieDTO movie)
        {
            Movie entity = new Movie()
            {
                Name = movie.Name,
                Description = movie.Description,
                PublisherId = movie.PublisherId,
                CategoryId = movie.CategoryId,
                ImageUrl = movie.ImageUrl,
                IMDb = movie.IMDb,
                PublishYear = movie.PublishYear,
            };
            _movieDal.Add(entity);
            return new SuccessResult(message: ResultMessages.MOVIE_ADDED);
        }

        public IResult Delete(Guid movieId)
        {
            Movie entity = _movieDal.Get(m => m.MovieId == movieId);
            _movieDal.Delete(entity);
            return new SuccessResult(message: ResultMessages.MOVIE_DELETED);

        }

        public IDataResult<MovieDTO> GetById(Guid movieId)
        {
            Movie response = _movieDal.Get(m => m.MovieId == movieId);
            MovieDTO entity = new MovieDTO()
            {
                Name = response.Name,
                Description = response.Description,
                PublisherId = response.PublisherId,
                CategoryId = response.CategoryId,
                ImageUrl = response.ImageUrl,
                IMDb = response.IMDb,
                MovieId = response.MovieId,
                PublishYear = response.PublishYear,
            };
            return new SuccessDataResult<MovieDTO>(entity);
        }

        public IDataResult<List<MovieDTO>> GetList()
        {
            List<Movie> movieList = _movieDal.GetAll().ToList();
            List<MovieDTO> responseList = new List<MovieDTO>();
            foreach (var movie in movieList)
            {
                var movieDTO = new MovieDTO()
                {
                    CategoryId = movie.CategoryId,
                    Description = movie.Description,
                    ImageUrl = movie.ImageUrl,
                    IMDb = movie.IMDb,
                    MovieId = movie.MovieId,
                    Name = movie.Name,
                    PublisherId = movie.PublisherId,
                    PublishYear = movie.PublishYear,
                };
                responseList.Add(movieDTO);
            }
            return new SuccessDataResult<List<MovieDTO>>(responseList);
        }

        public IDataResult<List<MovieDTO>> GetListByCategory(Guid categoryId)
        {
            var movieList = _movieDal.GetAll(m => m.CategoryId == categoryId).ToList();
            List<MovieDTO> responseList = new List<MovieDTO>();
            foreach (var movie in movieList)
            {
                var movieDTO = new MovieDTO()
                {
                    CategoryId = movie.CategoryId,
                    Description = movie.Description,
                    ImageUrl = movie.ImageUrl,
                    IMDb = movie.IMDb,
                    MovieId = movie.MovieId,
                    Name = movie.Name,
                    PublisherId = movie.PublisherId,
                    PublishYear = movie.PublishYear,
                };
                responseList.Add(movieDTO);
            }
            return new SuccessDataResult<List<MovieDTO>>(responseList);
        }

        public IResult Update(MovieDTO movie)
        {

            Movie databaseEntity = _movieDal.Get(m => m.MovieId == movie.MovieId);
            databaseEntity.Name = movie.Name;
            databaseEntity.Description = movie.Description;
            databaseEntity.PublisherId = movie.PublisherId;
            databaseEntity.CategoryId = movie.CategoryId;
            databaseEntity.ImageUrl = movie.ImageUrl;
            databaseEntity.IMDb = movie.IMDb;
            databaseEntity.PublishYear = movie.PublishYear;
            _movieDal.Update(databaseEntity);
            return new SuccessResult(message: ResultMessages.MOVIE_UPDATED);

        }


    }
}
