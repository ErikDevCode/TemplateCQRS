namespace TemplateCQRS.Application.Commons
{
    using System.Collections.Generic;

    public class PagedResult<T>
        where T : class
    {
        public PagedResult()
        {
            this.Results = new List<T>();
        }

        public int CurrentPage { get; set; }

        public int PageCount { get; set; }

        public int Count { get; set; }

        public IList<T> Results { get; set; }
    }
}
