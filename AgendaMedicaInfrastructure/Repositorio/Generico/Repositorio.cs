using AgendaMedicaInfrastructure.Dao;
using System;
using System.Data.Entity;
using System.Linq;

namespace AgendaMedicaInfrastructure.Repositorio.Generico
{
    public abstract class Repositorio<TEntity> : IDisposable, IRepositorio<TEntity> where TEntity : class
    {
        private readonly ContextoDb _contexto;

        public Repositorio(ContextoDb contexto)
        {
            _contexto = contexto;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _contexto.Set<TEntity>();
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return GetAll().Where(predicate).AsQueryable();
        }

        public TEntity Find(params object[] key)
        {
            return _contexto.Set<TEntity>().Find(key);
        }

        public void Atualizar(TEntity obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public void Adicionar(TEntity obj)
        {
            _contexto.Set<TEntity>().Add(obj);
        }

        public void Excluir(Func<TEntity, bool> predicate)
        {
            _contexto.Set<TEntity>()
                .Where(predicate).ToList()
                .ForEach(del => _contexto.Set<TEntity>().Remove(del));
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
