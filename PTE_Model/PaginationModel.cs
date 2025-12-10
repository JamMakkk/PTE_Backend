namespace PTE_Model
{
    public class PaginationModel<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; } = [];
    }
}
