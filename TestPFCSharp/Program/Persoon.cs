namespace Program
{
    public class Persoon
    {
        public Persoon(string voornaam, string familienaam)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
        }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }

        public override string ToString()
        {
            return Voornaam + ' ' + Familienaam;
        }
    }
}