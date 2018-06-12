using System.ComponentModel.DataAnnotations;

namespace DotNet_GoeBezig_G11.Models.MotivatieViewModels
{
    public class MaakMotivatieViewModel
    {
        [Required]
        public string Inhoud { get; set; }

        public MaakMotivatieViewModel() { }
        public MaakMotivatieViewModel(string inhoud)
        {
            Inhoud = inhoud;
        }
    }
}
