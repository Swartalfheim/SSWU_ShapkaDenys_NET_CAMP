namespace M4HW3.Configurats
{
    public class Languagegroup
    {
        public int LanguagegroupId { get; set; }
        public string Name { get; set; }
        public List<Languages> Languages { get; set; } = new List<Languages>();
    }
}
