using System.Collections.Generic;

namespace OctetWebApi.Biz.Markup.Queries.GetMarkupQuery
{
    public class MarkupsVm
    {
        public IReadOnlyList<MarkupDto> Markups { get; set; }
    }
}