using System.Linq.Expressions;

namespace TransportSystemWebApp.Services
{
    public class Service<TEntity> : IService<TEntity>
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TEntity value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Value cant be null");
            }

            await _repository.AddAsync(value);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("Values cant be null");
            }

            await _repository.AddRangeAsync(values);
        }

        public async Task DeleteAsync(TEntity value) => await _repository.DeleteAsync(value);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
           TEntity entity = await _repository.GetAsync(predicate);

            if (entity == null)
                throw new Exception("Cant find");

            return entity;
        }

        public async Task UpdateAsync(TEntity newEntity)
        {
            if(newEntity == null)
            {
                throw new ArgumentNullException("Value cant be null");
            }

            await _repository.UpdateAsync(newEntity);
        }
    }
}
