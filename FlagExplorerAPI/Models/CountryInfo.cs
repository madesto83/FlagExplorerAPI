namespace FlagExplorerAPI.Models
{
    public class CountryInfo
    {
        public Name Name { get; set; }
        public Flags Flags { get; set; }
        public int Population { get; set; }
        public string[] Capital { get; set; }
    }
}
