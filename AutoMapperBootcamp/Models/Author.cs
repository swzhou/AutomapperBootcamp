namespace Com.Swzhou.Automapper.Bootcamp.Models
{
    public class Author
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ContactInfo ContactInfo { get; set; }

        public bool IsNull()
        {
            return string.IsNullOrEmpty(Name)
                       && string.IsNullOrEmpty(Description)
                       && ContactInfo == null;
        }
    }
}