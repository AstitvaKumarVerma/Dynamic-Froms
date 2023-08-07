namespace DynamicFormAPI.Models.ResponseModel
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
    public class ResponseData<T> : ResponseDto
    {
        public T SingleData { get; set; }
    }
    public class ListResponse<T> : ResponseDto
    {
        public List<T> DataList { get; set; }
    }
}
