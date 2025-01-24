using System.ComponentModel.DataAnnotations;
namespace Dima.Core.Requests.Categories;

public class UpdateCategoryRequest : Request
{

    public long Id { get; set; }
    
    [Required(ErrorMessage = "Título Inválido.")]
    [MaxLength(80, ErrorMessage = "O título deve conter ate 80 caracteres.")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Descrição Inválido.")]
    public string Description { get; set; } = string.Empty;
}