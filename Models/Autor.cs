﻿namespace KnjigaAutorCRUD.Models
{
    public class Autor
    {
        public int Id { get; set; }

        public string? Ime { get; set; }

        public string? Prezime { get; set; }

        public List<AutorKnjiga>? AutoriKnjige { get; set; }
    }
}
