namespace PTE_Model
{
    public abstract class WfdBaseModel
    {
        public string Content { get; set; } = null!;
    }
    public class WfdModel : WfdBaseModel
    {
        public int Id { get; set; }
        public int? SeqNo { get; set; }
        public bool? IsTested { get; set; }
    }
    public class CreateWfdModel: WfdBaseModel { }
    public class UpdateWfdModel : WfdBaseModel 
    {
        public int Id { get; set; }
    }
    public class SearchWfdModel
    {
        public string? Content { get; set; } 
        public bool? IsTested { get; set; }
    }

}
