using ALazy.Dev.BaseComponents;
using ALazy.Dev.Models.LaData;

namespace ALazy.Dev.Models.RequestModels
{
    public class AppRequest : LaRequestModel<LaApp>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public override LaApp Map()
        {
            var app = new LaApp();
            app.Name = Name;
            app.Description = Description;
            app.OrgID = 1;

            return app;
        }
    }
}
