using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //class:bir referans tip olması gerek
    //IEntity:Ientitiy olabilir yada IEntitiy iplemente eden bir class olabilir
    //new():new 'lenebilir bir nesne olabilir yani interface olamaz
   public interface IEntityRepository<T> where T: class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
