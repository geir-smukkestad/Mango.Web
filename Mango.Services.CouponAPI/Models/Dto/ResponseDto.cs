namespace Mango.Services.CouponAPI.Models.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }
        public bool IsSuccessFul { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
