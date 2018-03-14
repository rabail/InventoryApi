using System.Collections.Generic;

namespace InventoryManagementService
{
    public interface IMapper
    {
        Dictionary<int, Descriptor> GetMapper();
    }
}