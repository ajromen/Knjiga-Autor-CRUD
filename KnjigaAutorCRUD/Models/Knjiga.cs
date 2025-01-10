namespace KnjigaAutorCRUD.Models
{
    public class Knjiga
    {
        public int Id { get; set; }

        public required string Naslov { get; set; }

        public required int GodinaIzdanja { get; set; }

        public List<AutorKnjiga>? AutoriKnjige { get; set; }
    }
}
