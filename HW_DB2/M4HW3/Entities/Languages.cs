namespace M4HW3.Configurats
{
    public class Languages
    {
        public int LanguagesId { get; set; }
        public string Name { get; set; }

        public int LanguagegroupId { get; set; }

        public Languagegroup Languagegroup { get; set; }

        public List<CountriesLanguages> CountriesLanguages { get; set; } = new List<CountriesLanguages>();
    }
}
