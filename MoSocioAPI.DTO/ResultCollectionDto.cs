using System.Collections.Generic;

namespace MoSocioAPI.DTO
{
    public class ResultCollectionDto<T> where T : class
    {
        public int Count { get; set; }
        public int RecordsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public ICollection<T> Data { get; set; }
    }
}
