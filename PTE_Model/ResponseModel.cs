
namespace PTE_Model
{
    public class GeneralResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Response { get; set; }
    }
}
