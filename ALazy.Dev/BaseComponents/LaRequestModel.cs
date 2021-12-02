using ALazy.Dev.Models.LaData;

namespace ALazy.Dev.BaseComponents
{
    public abstract class LaRequestModel<TModel> where TModel : LaModel
    {
        public abstract TModel Map();
    }
}
