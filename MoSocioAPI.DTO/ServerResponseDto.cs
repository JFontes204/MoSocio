using MoSocioAPI.Model.Configuration;
using TypeLite;

namespace MoSocioAPI.DTO
{
    [TsClass(Module = Constants.TsModule)]
    public class ServerResponseDto
    {
        public int StatusId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public object Object { get; set; }
    }
}
