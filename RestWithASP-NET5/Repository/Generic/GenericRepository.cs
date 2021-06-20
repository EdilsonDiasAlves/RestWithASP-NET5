using Microsoft.EntityFrameworkCore;
using RestWithASP_NET5.Model.Base;
using RestWithASP_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {

        private MySQLContext _context;

        private DbSet<T> _dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }




        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault<T>(p => p.Id.Equals(id));
        }
        public T Create(T entity)
        {
            try
            {
                _dataSet.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Update(T entity)
        {
            var result = _dataSet.SingleOrDefault<T>(p => p.Id.Equals(entity.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return entity;
                }
                catch (Exception)
                {
                    throw;
                }
            } 
            else
            {
                return null;
            }
        }
        public void Delete(long id)
        {
            var result = _dataSet.SingleOrDefault<T>(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _dataSet.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        public bool Exists(long id)
        {
            return _dataSet.Any(p => p.Id.Equals(id));
        }
    }
}
