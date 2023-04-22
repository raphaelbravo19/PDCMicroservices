using CorePDC.Common;
using StoresApi.Interfaces;
using StoresApi.Interfaces.Requests;

namespace StoresApi.Services
{
    public class StoreService : IStoreService
    {
        private readonly IAlblasaContext _alblasaContext;
        private readonly ILogger _logger;

        public StoreService(IAlblasaContext alblasaContext, ILogger<IStoreService> logger)
        {
            _alblasaContext = alblasaContext;
            _logger = logger;
        }

        public SimpleItemListResponse<Store> GetStores()
        {
            try
            {
                var stores = _alblasaContext.Stores.ToList();

                return new SimpleItemListResponse<Store>
                {
                    ErrorCode = "200",
                    ErrorMessage = "The stores have been succesfully retrieved",
                    Items = stores
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new SimpleItemListResponse<Store>
                {
                    ErrorCode = "500",
                    ErrorMessage = ex.Message
                };
            }
        }

        public SingleItemResponse<Store> GetStore(int storeId)
        {
            try
            {
                var store = _alblasaContext.Stores.Find(storeId);

                if (store == null)
                {
                    return new SingleItemResponse<Store>
                    {
                        ErrorCode = "204",
                        ErrorMessage = "The storeId is invalid"
                    };
                }

                return new SingleItemResponse<Store>
                {
                    ErrorCode = "200",
                    ErrorMessage = "The store has been succesfully retrieved",
                    Item = store
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new SingleItemResponse<Store>
                {
                    ErrorCode = "500",
                    ErrorMessage = ex.Message
                };
            }
        }

        public SingleItemResponse<Store> CreateStore(DtoStore dtoStore)
        {
            try
            {
                var store = new Store
                {
                    Name = dtoStore.Name,
                    Company = dtoStore.Company,
                    Address = dtoStore.Address
                };

                _alblasaContext.Stores.Add(store);
                _alblasaContext.SaveChanges();

                return new SingleItemResponse<Store>
                {
                    ErrorCode = "200",
                    ErrorMessage = "The store has been succesfully created",
                    Item = store
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new SingleItemResponse<Store>
                {
                    ErrorCode = "500",
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
