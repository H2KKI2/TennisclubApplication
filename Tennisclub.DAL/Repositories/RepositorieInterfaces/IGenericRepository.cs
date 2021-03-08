using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Tennisclub.DAL.Repositories
{
    public interface IGenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto> 
        where TEntity : class 
        where TReadDto : class 
        where TCreateDto : class 
        where TUpdateDto : class
    {
        TReadDto GetById(int id);
        IEnumerable<TReadDto> GetAll();
        IEnumerable<TReadDto> GetAllFiltered(Func<TEntity, bool> filter);
        TReadDto Add(TCreateDto item);
        TReadDto Update(TUpdateDto item);
        void Delete(int id);
        void Save();
    }
}
