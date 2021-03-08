using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Tennisclub.DAL.Data;

namespace Tennisclub.DAL.Repositories
{
    public class GenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto> : IGenericRepository<TEntity, TReadDto, TCreateDto, TUpdateDto> 
        where TEntity : class
        where TReadDto : class
        where TCreateDto : class
        where TUpdateDto : class

    {
        internal readonly TennisclubContext _context;
        internal readonly IMapper _mapper;
        internal readonly DbSet<TEntity> _dbSet;

        public GenericRepository(TennisclubContext context, IMapper mapper)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
            _mapper = mapper;
        }
        public virtual List<TEntity> _GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public virtual IEnumerable<TReadDto> GetAll()
        {
            return _mapper.Map<IEnumerable<TReadDto>>(_GetAll());
        }
        public virtual IEnumerable<TReadDto> GetAllFiltered(Func<TEntity, bool> filter)
        {
            return _mapper.Map<IEnumerable<TReadDto>>(_GetAll().Where(filter).ToList());
        }
        public virtual TReadDto GetById(int id)
        {
            if (id < 1) throw new ArgumentOutOfRangeException("Items can not have an id below 1.");

            return _mapper.Map<TReadDto>(_dbSet.Find(id));
        }
        public TReadDto Add(TCreateDto item)
        {
            var entry = _dbSet.Add(_mapper.Map<TEntity>(item));
            Save();

            return _mapper.Map<TReadDto>(entry.Entity);
        }
        public virtual TReadDto Update(TUpdateDto item)
        {

            var updateItem = _dbSet.Update(_mapper.Map<TEntity>(item));
            Save();

            return _mapper.Map<TReadDto>(updateItem.Entity);
        }
        public virtual void Delete(int id)
        {
            TEntity item = _dbSet.Find(id);

            if (item == null)
                throw new NullReferenceException("Item with this id is not found");

            _dbSet.Remove(_mapper.Map<TEntity>(item));
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
