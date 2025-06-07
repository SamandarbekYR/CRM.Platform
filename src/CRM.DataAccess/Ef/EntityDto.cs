using AutoMapper;

namespace CRM.DataAccess.Ef
{
    public class EntityDto<TDto, TEntity> : IEntityDto<TEntity> where TDto : EntityDto<TDto, TEntity> where TEntity : class
    {
        private TEntity _entity;

        protected virtual Action<IMappingExpression<TDto, TEntity>> AlterMapping => null;

        protected virtual Action<IMappingExpression<TDto, TEntity>> AlterCreateMapping => null;

        protected virtual Action<IMappingExpression<TDto, TEntity>> AlterUpdateMapping => null;

        public TEntity GetEntity()
        {
            return _entity;
        }

        public virtual TEntity CreateEntity()
        {
            if (AlterCreateMapping != null)
            {
                _entity = new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
                {
                    AlterCreateMapping(cfg.CreateMap<TDto, TEntity>());
                }).CreateMapper().Map<TEntity>((TDto)this);
            }
            else if (AlterMapping != null)
            {
                _entity = new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
                {
                    AlterMapping(cfg.CreateMap<TDto, TEntity>());
                }).CreateMapper().Map<TEntity>((TDto)this);
            }
            else
            {
                _entity = new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
                {
                    cfg.CreateMap<TDto, TEntity>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); ;
                }).CreateMapper().Map<TEntity>((TDto)this);
            }

            return _entity;
        }

        public virtual void UpdateEntity(TEntity entity)
        {
            _entity = entity;
            MapperConfiguration mapperConfiguration = null;
            mapperConfiguration = ((AlterUpdateMapping != null) ? new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
            {
                AlterUpdateMapping(cfg.CreateMap<TDto, TEntity>());
            }) : ((AlterMapping == null) ? new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<TDto, TEntity>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            }) : new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
            {
                AlterMapping(cfg.CreateMap<TDto, TEntity>());
            })));
            mapperConfiguration.CreateMapper().Map((TDto)this, entity);
        }
    }
}
