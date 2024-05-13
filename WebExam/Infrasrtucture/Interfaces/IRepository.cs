﻿namespace WebExam.Infrasrtucture.Interfaces
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        List<T> Get();
        T Get(int entityId);
        int Insert(T entity);
        bool Update(T entity);
        bool Delete(int entityId);
    }
}
