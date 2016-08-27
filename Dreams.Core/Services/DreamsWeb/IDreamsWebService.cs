using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dreams.Core.Services.DreamsWeb
{
    public interface IDreamsWebService
    {
        Task<List<DreamsWebServiceDTO>> FetchAsync();
    }
}
