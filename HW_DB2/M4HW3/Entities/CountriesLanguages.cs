namespace M4HW3.Configurats
{
    public class CountriesLanguages
    {
        public int CountriesLanguagesId { get; set; }
        public int LanguagesId { get; set; }
        public int CountriesId { get; set; }

        public Languages Languages { get; set; }
        public Countries Countries { get; set; }
    }
}
