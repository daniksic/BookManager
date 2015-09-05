using BookManager.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.BL.Repository
{
    public abstract class RepositoryBase<Model> : IRepository<Model> where Model: BookManager.Entities.EntityBase
    {
        protected DbContext Context;

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }


        /// <summary>
        /// Gets Entity by Id
        /// </summary>
        /// <param name="id">Id of Entity</param>
        /// <returns></returns>
        public virtual Model Get(int id)
        {
            return Context.Set<Model>().First(e => e.Id == id);
        }

        /// <summary>
        /// Gets list of Entities by pagination
        /// </summary>
        /// <param name="page">Number of page</param>
        /// <param name="size">Size of list per page</param>
        /// <returns></returns>
        public virtual IEnumerable<Model> GetByPage(int page, int size = 10)
        {
            return Context.Set<Model>().Take(size).Skip(page * size).ToList();
        }

        /// <summary>
        /// Adds new or updates old entity
        /// </summary>
        /// <param name="entity">Entity on which you want to perform action</param>
        /// <returns></returns>
        public virtual Model AddOrUpdate(Model entity)
        {
            if (entity.Id > 0)
            {
                //Update
                Context.Entry(entity).State = EntityState.Modified;
                Context.SaveChanges();
                return entity;
            }
            else
            {
                //Add new
                var newEnt = Context.Set<Model>().Add(entity);
                Context.SaveChanges();
                return newEnt;
            }
        }

        /// <summary>
        /// Marks Entity record as deleted
        /// </summary>
        /// <param name="entity">Entity on which you want to perform action</param>
        /// <returns></returns>
        public bool Delete(Model entity)
        {
            entity.IsDeleted = true;
            Context.Entry(entity).State = EntityState.Modified;
            var numOfChanges = Context.SaveChanges();

            return (numOfChanges > 0) ? true : false;
        }
    }
}
