using CorePDC.Common;
using StoresApi.Interfaces.Requests;

namespace StoresApi.Interfaces
{
    public interface IStoreService
    {
        SimpleItemListResponse<Store> GetStores();
        SingleItemResponse<Store> GetStore(int storeId);
        SingleItemResponse<Store> CreateStore(DtoStore dtoStore);
    }
}
