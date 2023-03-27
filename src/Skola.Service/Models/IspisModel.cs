namespace Skola.Service.Models
{
    public class IspisModel
    {
        public string ImeUcenika { get; set; }
        public string PrezimeUcenika { get; set; }
        public string ImeProfesora { get; set; }
        public string PrezimeProfesora { get; set; }
        public string NazivPredmeta { get; set; }
        public int ZakljucnaOcjena { get; set; }

        public IspisModel(string imeUcenika, string prezimeUcenika, string imeProfesora, string prezimeProfesora, string nazivPredmeta, int zakljucnaOcjena)
        {
            ImeUcenika = imeUcenika;
            PrezimeUcenika = prezimeUcenika;
            ImeProfesora = imeProfesora;
            PrezimeProfesora = prezimeProfesora;
            NazivPredmeta = nazivPredmeta;
            ZakljucnaOcjena = zakljucnaOcjena;
        }
    }
}
