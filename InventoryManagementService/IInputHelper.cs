using System.Threading.Tasks;

namespace InventoryManagementService
{
    public interface IInputHelper
    {
        Task<InventoryModel> GetInputAsString();
    }
}