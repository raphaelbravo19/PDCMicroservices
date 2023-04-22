namespace CorePDC.Common
{
    public class BaseResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class SimpleItemListResponse<T> : BaseResponse
    {
        public IEnumerable<T> Items { get; set; }
        public int Count
        {
            get { return Items.Count(); }
        }
    }

    public class SingleItemResponse<T> : BaseResponse
    {
        public T Item { get; set; }
    }
}
