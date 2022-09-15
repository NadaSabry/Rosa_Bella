namespace Rosa_Bella.Models.Repo_Interface
{
    public interface RosaRepository<TEntity>
    {
        TEntity Find(int id);
        IList<TEntity> list();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int Id);
    }
}
