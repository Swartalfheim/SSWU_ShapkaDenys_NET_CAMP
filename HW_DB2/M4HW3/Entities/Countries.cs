namespace M4HW3.Configurats
{
    public class Countries
    {
        public int CountriesId { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }
        public List<CountriesLanguages> CountriesLanguages { get; set; } = new List<CountriesLanguages>();
    }
}
