using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp13.Entities;

namespace ConsoleApp13.Repos
{
    internal class Repository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : class
    {
        private readonly Client _client;
        private readonly string _url;

        public Repository(Client client, string url)
        {
            _client = client;
            _url = url;
        }

        public async Task AddAsync(TEntity value)
        {
            string addUrl = $"{_url}/Add";
            await _client.PostRequest(addUrl, value);
        }

        public async Task DeleteAsync(TKey id)
        {
            string deleteUrl = $"{_url}/Delete?id={id}";
            await _client.DeleteRequest(deleteUrl);
        }

        public async Task UpdateAsync(TEntity newEntity)
        {
            string updateUrl = $"{_url}/Update";
            await _client.PutRequest(updateUrl, newEntity);

        }

        public async Task<TEntity> GetAsync(TKey key)
        {
            string getUrl = $"{_url}/GetById?id={key}";
            return await _client.GetRequest<TEntity>(getUrl);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            string getAllUrl = $"{_url}/GetAll";
            return await _client.GetRequest<IEnumerable<TEntity>>(getAllUrl);
        }
    }
}
