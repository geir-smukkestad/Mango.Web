using Mango.Common.Dto;
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(Models.RequestDto requestDto);
    }
}
