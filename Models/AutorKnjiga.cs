namespace KnjigaAutorCRUD.Models
{
    public class AutorKnjiga
    {
        public int KnjigaId { get; set; }
        public Knjiga? Knjiga { get; set; }

        public int AutorId { get; set; }
        public Autor? Autor { get; set; }
    }
}
