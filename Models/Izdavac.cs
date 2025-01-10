namespace KnjigaAutorCRUD.Models
{
    public class Izdavac
    {
        public int Id { get; set; }
        public string? Ime { get; set; }
        
        public List<Knjiga>? Knjige { get; set; }
    }
}
