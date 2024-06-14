namespace MVCApplication.Models.Common
{
    public class GencClass<TEntity> where TEntity : class
    {
        List<TEntity> entities= new List<TEntity>();
    }
}
