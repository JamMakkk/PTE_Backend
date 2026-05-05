
namespace PTE_Model
{
    public abstract class MemberBaseModel
    {
        public string Username { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
    public class MemberModel : MemberBaseModel
    {
        public int Id { get; set; }
        public int? Status { get; set; }
        public int? TokenVersion { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? LastModifiedBy { get; set; }
    }
    public class CreateMemberModel : MemberBaseModel
    {
        public string? Password { get; set; }
    }
    public class UpdateMemberModel : MemberBaseModel
    {
        public int Id { get; set; }
    }
    public class SearchMemberModel
    {

    }

}
