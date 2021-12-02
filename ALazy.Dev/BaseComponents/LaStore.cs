using ALazy.Dev.LaComponents;
using ALazy.Dev.Models.LaData;
using Microsoft.EntityFrameworkCore;

namespace ALazy.Dev.BaseComponents
{
    public abstract class LaStore<TModel, TRequestModel> where TModel : LaModel where TRequestModel : LaRequestModel<TModel>
    {
        protected DbSet<TModel> Dataset { get; set; }
        protected LaAppDBContext DB { get; set; }
        public LaStore(LaAppDBContext context, DbSet<TModel> dataset)
        {
            DB = context;
            Dataset = dataset;
        }
        public TModel Create(TRequestModel r)
        {
            var m = r.Map();

            Dataset.Add(m);
            DB.SaveChanges();
            
            return m;
        }
    }
}
