using AutoMapper;

namespace Common.Mappers
{
    public class CustomMapper<TDto, TEntity>
    {
        private readonly IMapper _mapper;

        public CustomMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDto ToDto(TEntity entity)
        {
            return _mapper.Map<TEntity, TDto>(entity);
        }

        public TEntity ToEntity(TDto dto)
        {
            return _mapper.Map<TDto, TEntity>(dto);
        }
    }
}
