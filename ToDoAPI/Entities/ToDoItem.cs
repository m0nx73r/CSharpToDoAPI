namespace ToDoAPI.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Task { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? CreatedUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ModifiedUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }

}
