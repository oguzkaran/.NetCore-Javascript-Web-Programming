using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using static CSD.Util.Data.DatabaseUtil;

namespace CSD.Util.Data.Repository
{
    public class CrudRepositoryEx<Entity, ID, Context> : CrudRepository<Entity, ID, Context>, ICrudRepository<Entity, ID>
        where Entity : class, IEntity<ID>
        where Context : DbContext
    {
        public CrudRepositoryEx(Context context) : base(context) { }

        new public IEnumerable<Entity> All => DoWorkForRepository(() => base.All, "CrudRepositoryEx.All");

        new public long Count() => DoWorkForRepository(() => base.Count(), "CrudRepositoryEx.Count");        

        new public void Delete(Entity entity) => DoWorkForRepository(() => base.Delete(entity), "CrudRepositoryEx.Delete");

        new public void DeleteById(ID id) => DoWorkForRepository(() => base.DeleteById(id), "CrudRepositoryEx.DeleteById");

        new public bool ExistsById(ID id) => DoWorkForRepository(() => base.ExistsById(id), "CrudRepositoryEx.ExistsById");        

        new public Entity FindById(ID id) => DoWorkForRepository(() => base.FindById(id), "CrudRepositoryEx.FindById");

        new public IEnumerable<Entity> FindByIds(IEnumerable<ID> ids) => DoWorkForRepository(() => base.FindByIds(ids), "CrudRepositoryEx.FindByIds");

        new public Entity Save(Entity entity) => DoWorkForRepository(() => base.Save(entity), "CrudRepositoryEx.Save");        

        new public IEnumerable<Entity> Save(IEnumerable<Entity> entities) => DoWorkForRepository(() => base.Save(entities), "CrudRepositoryEx.SaveAll");
    }
}
