﻿using System.Text.Json.Serialization;

namespace WebApi8.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public bool Se_Disponivel { get; set; }
        public AutorModel? Autor { get; set; }
    }
}