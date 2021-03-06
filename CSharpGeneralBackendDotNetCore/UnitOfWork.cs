﻿using System;
using CSharpGeneralBackendDDotNetCore.Interfaces;
using CSharpGeneralBackendDDotNetCore.Providers;

namespace CSharpGeneralBackendDDotNetCore
{
    public abstract class UnitOfWork<T, T2> : IDisposable
        where T : IDbContext, new() 
        where T2: ServiceProvider
    {
        private T _dbContext;
        protected T DbContext
        {
            get
            {
                return Equals(_dbContext, default(T))
                    ? (_dbContext = new T())
                    : _dbContext;
            }
        }

        public void ExcecuteStatement(Action<T2> statement)
        {
            statement(ServiceProvider);
        }

        public T3 ReadStatement<T3>(Func<T2, T3> statement)
        {
            return statement(ServiceProvider);
        }

        protected abstract T2 ServiceProvider { get; }
        public void Dispose()
        {
            if(_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
