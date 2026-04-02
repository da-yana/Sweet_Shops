namespace sweetshops.Model
{
    public class Client : EFModel
    {
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public int NumberOrder { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
