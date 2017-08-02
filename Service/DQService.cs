using Common;
using ExpressionSerialization;
using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Service
{
    public class DQService : IDQService
    {
        Db db = new Db();
        public dynamic Excute(Command cmd)
        {
            return cmd.Execute();
        }

        public bool Ping()
        {
            return true;
        }

        public Entity GetEntityById(Entity entity)
        {

            var entity1 = db.Set(entity.GetType()).Find(entity.Id);
            return entity1 as Entity;
        }
        public void Insert(Entity entity)
        {
            entity.CreateOn = DateTime.Now;
            entity.UpdateOn = DateTime.Now;
            db.Entry(entity).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
        }
        public void Update(Entity entity)
        {
            entity.UpdateOn = DateTime.Now;
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Entity entity)
        {
            entity.IsActive = false;
            entity.UpdateOn = DateTime.Now;
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public IQueryable<User> Query(Entity entity, XElement xmlPredicate)
        {
            var predicate = SerializeHelper.DeserializeExpression<User, bool>(xmlPredicate);

            return (db.Set(entity.GetType()).AsQueryable() as IQueryable<User>).Where(predicate);
        }
    }
}
