using Application.Dtos;


namespace Application.IServices.AdminServices.ConfirmServices
{
    /// <summary>
    /// کالاهای در انتظار تایید را تایید/رد می کند
    /// </summary>
    public interface IConfirmForAddProductService
    {
        Task<GeneralDto> ExecuteFalse(int id);
        Task<GeneralDto> ExecuteTrue(int id);
    }
}
