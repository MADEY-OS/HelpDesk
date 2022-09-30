namespace HelpDesk.Client.ViewModels
{
    public class RequestsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public virtual string Category { get; set; }
        public virtual string User { get; set; }
        public virtual string Device { get; set; }
        public int FixerId { get; set; }
        public string FixerOpinion { get; set; }
    }
}
