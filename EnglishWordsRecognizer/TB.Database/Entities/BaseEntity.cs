namespace TB.Database.Entities
{
    public class BaseEntity<T>
    {
        public virtual T Id { set; get; }
    }
}
