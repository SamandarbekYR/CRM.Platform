namespace CRM.DataAccess.Ef;

public interface IEntityDto<TEntity>
{
    TEntity GetEntity();

    TEntity CreateEntity();

    void UpdateEntity(TEntity entity);
}
