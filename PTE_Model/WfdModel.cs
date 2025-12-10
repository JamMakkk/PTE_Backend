namespace PTE_Model
{
    public class WfdBaseModel
    {
        public string Content { get; set; } = null!;
    }
    public class WfdModel : WfdBaseModel
    {
        public int Id { get; set; }
        public int? SeqNo { get; set; }
        public bool? IsTested { get; set; }

    }
}
