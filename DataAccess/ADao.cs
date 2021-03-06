using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Extensions;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace DataAccess
{

    public class ADao
    {
        public PruebaContext Context { get; }
        protected EntityState StateInsert = EntityState.Added;
        protected ADao(PruebaContext _PruebaContext)
        {
            Context = _PruebaContext;
            EntityFrameworkManager.ContextFactory = context => _PruebaContext;
        }
        public bool InsertUpdateOrDelete<T>(T entity, string transaction) where T : class
        {

            var stateRegister = transaction == "I" ? EntityState.Added : transaction == "U" ? EntityState.Modified : EntityState.Deleted; ;

            if (stateRegister != EntityState.Deleted)
            {
                Context.Set<T>().Add(entity);
                Context.Entry(entity).State = stateRegister;
            }
            else
            {
                Context.Set<T>().Remove(entity);
            }



            Context.SaveChanges();



            return true;
        }
        public T InsertUpdateOrDeleteSelectAll<T>(T entity, string transaction) where T : class
        {
            try
            {
                var stateRegister = transaction == "I" ? EntityState.Added : transaction == "U" ? EntityState.Modified : EntityState.Deleted; ;

                if (stateRegister != EntityState.Deleted)
                {
                    Context.Set<T>().Add(entity);
                    Context.Entry(entity).State = stateRegister;
                }
                else
                {
                    Context.Set<T>().Remove(entity);
                }
                Context.SaveChanges();
                return entity;
            }
            catch (Exception e)
            {

                return null;
            }




        }
        public List<T> GetPaginatedList<T>(int pageIndex, int pageSize) where T : class, IEntity
        {
            var sortedList = Context.Set<T>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return sortedList;
        }


        public List<T> SelectEntity<T>() where T : class
        {

            try
            {
                var _dataTable = Context.Set<T>()
                         .ToList();
                return _dataTable;
            }
            catch (Exception e)
            {
                return null;

            }

        }
        public void Update<T>(T entity) where T : class
        {
            Context.Update(entity);
        }

        public void PhysicalDelete<T>(T entity) where T : class
        {
            try
            {


                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    Context.Set<T>().Add(entity);
                }

                Context.Set<T>().Remove(entity);

                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
    }
}
