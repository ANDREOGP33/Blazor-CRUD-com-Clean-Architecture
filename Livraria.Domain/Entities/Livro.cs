﻿using Livraria.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Domain.Entities
{
    public sealed class Livro
    {
        public int LivroId { get; set; }

        [Required(ErrorMessage ="Informe o título do Livro")]
        [StringLength(100)]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Informe o Autor do Livro")]
        [StringLength(50)]
        public string? Autor { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento do Livro")]
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "Informe a imagem da capa")]
        [StringLength(200)]
        public string? Capa { get; set; }

        [Required]
        [EnumDataType(typeof(Editora), ErrorMessage ="Selecione a editora")]
        public Editora Editora { get; set; }

        [Required]
        [EnumDataType(typeof(Categoria), ErrorMessage ="Selecione a categoria")]
        public Categoria Categoria { get; set; }

        public Livro(int livroId, string? titulo, string? autor, DateTime lancamento, string? capa, Editora editora, Categoria categoria)
        {
            LivroId = livroId;
            Titulo = titulo;
            Autor = autor;
            Lancamento = lancamento;
            Capa = capa;
            Editora = editora;
            Categoria = categoria;
        }
    }
}
