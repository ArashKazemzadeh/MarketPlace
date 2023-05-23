namespace Common.Mappers;

public interface ICustomMapper<TDto, TEntity>
{
    TDto ToDto(TEntity entity);
    TEntity ToEntity(TDto dto);
}