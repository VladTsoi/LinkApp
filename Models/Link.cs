using System.ComponentModel.DataAnnotations;

namespace LinkApp.Models
{
    public class Link
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите url!")]
        [Url(ErrorMessage ="Введите правильный url!")]
        public string? Url { get; set; }
        [Display(Name = "Короткий URL")]
        public string? ShortUrl { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime Date { get; set; }
        [Display(Name = "Количество переходов")]
        public int Transition { get; set; }
    }
}
