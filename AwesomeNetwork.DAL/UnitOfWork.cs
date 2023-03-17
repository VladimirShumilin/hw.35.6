using AwesomeNetwork.DAL.Interfaces;
using AwesomeNetwork.DAL.Repository;

using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeNetwork.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private  ApplicationDbContext _appContext;

        private Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext app)
        {
            this._appContext = app;
        }
        
        public void Dispose()
        {
            //Dispose(true);
            //GC.SuppressFinalize(this);
        }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        if (_appContext != null)
        //        {
        //            _appContext.Dispose();
        //            _appContext = null;
        //        }
        //    }
        //}

        public IRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = true) where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();

            if (hasCustomRepository)
            {
                var customRepo = _appContext.GetService<IRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<TEntity>(_appContext);
            }

            return (IRepository<TEntity>)_repositories[type];
           
        }
        public int SaveChanges(bool ensureAutoHistory = false)
        {
            return _appContext.SaveChanges(ensureAutoHistory);
        }
    }
}
