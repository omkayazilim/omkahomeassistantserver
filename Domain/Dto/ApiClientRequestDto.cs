
namespace Domain.Dto
{
    public class ApiClientRequestDto
    {
        public string RequestUrl { get; set; }  
        public string RequestMetod { get; set; }    

    }

    public class ApiClientRequestDto<T>:ApiClientRequestDto
    {
          public T RequestData { get; set; }
    }


}
