using ALazy.Dev.BaseComponents;
using ALazy.Dev.LaComponents;
using ALazy.Dev.Models.LaData;
using ALazy.Dev.Models.RequestModels;
using Microsoft.EntityFrameworkCore;

namespace ALazy.Dev.Stores
{
    public class AppsStore : LaStore<LaApp, AppRequest>
    {
        public AppsStore(LaAppDBContext context) : base(context, context.Apps)
        {
        }
    }
}
