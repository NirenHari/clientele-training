using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using AsbaBank.Core;

namespace AsbaBank.Infrastructure
{
    sealed class SqlRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> DataSet { get; set; }
        private readonly PropertyInfo identityPropertyInfo;

        public SqlRepository(DbContext context)
        {
            DataSet  = context.Set<TEntity>();
            identityPropertyInfo = GetIdentityPropertyInformation();
        }

        private PropertyInfo GetIdentityPropertyInformation()
        {
            return typeof(TEntity)
                .GetProperties()
                .Single(propertyInfo => Attribute.IsDefined((MemberInfo)propertyInfo, typeof(KeyAttribute)));
        }
        public IEnumerator<TEntity> GetEnumerator()
        {
            return DataSet.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        
        public void Add(TEntity item)
        {
            DataSet.Add(item);

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TEntity item)
        {
            return DataSet.Contains(item);
        }

        public void CopyTo(TEntity[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(TEntity item)
        {
            return DataSet.Remove(item) != null;
        }

        public int Count { get; private set; }
        public bool IsReadOnly { get; private set; }

        public TEntity Get(object id)
        {
            return DataSet.Find(id);
        }

        private Func<TEntity, bool> WithMatchingId(object id)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TEntity), "x");
            Expression property = Expression.Property(parameter, identityPropertyInfo.Name);
            Expression target = Expression.Constant(id);
            Expression equalsMethod = Expression.Equal(property, target);
            Func<TEntity, bool> predicate = Expression.Lambda<Func<TEntity, bool>>(equalsMethod, parameter).Compile();

            return predicate;
        }

        public void Update(object id, TEntity item)
        {
            var entity=(TEntity)DataSet.Where(e => e.Equals(Get(id)));
            entity = item;
        }
    }
}
