﻿using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Email do contato")]
        [EmailAddress(ErrorMessage = "O email-informado não é válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "O celular não é válido")]
        public string Celular {get; set;}
    }
}
