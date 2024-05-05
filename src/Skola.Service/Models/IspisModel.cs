namespace Skola.Service.Models
{
    public class IspisModel
    {
        public Guid Trgovac { get; set; }
        public Guid Poslovnica { get; set; }
        public Guid Predmet { get; set; }
        public Guid Kupac { get; set; }


        public IspisModel(Guid Trgovac, Guid Poslovnica, Guid Predmet, Guid Kupac)
        {
            Trgovac = Trgovac;
            Poslovnica = Poslovnica;
            Predmet = Predmet;
            Kupac = Kupac;
        }
    }
}
