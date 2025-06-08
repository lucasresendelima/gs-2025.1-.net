using System.ComponentModel.DataAnnotations;

namespace GestaoAbrigos_WebApp.Application.Dtos
{
    public class LocalizacaoDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = $"Campo {nameof(Rua)} é obrigatório")]
        public string Rua { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Numero)} é obrigatório")]
        public string Numero { get; set; } = string.Empty;

        public string Complemento { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Cidade)} é obrigatório")]
        public string Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Estado)} é obrigatório")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = $"Campo {nameof(Cep)} é obrigatório")]
        public string Cep { get; set; } = string.Empty;
    }
}

