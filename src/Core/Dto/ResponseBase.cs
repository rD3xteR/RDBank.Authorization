namespace Core.Dto;

public class ResponseBase<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
}
