using System.ComponentModel.DataAnnotations;

namespace Queridometro.Core.Entities
{
    public enum Emoji
    {
        Cobra,
        Nojo,
        Feliz,
        Triste,
        Bomba,
        Coração,
        [Display(Name = "Coração Quebrado")]
        CoraçãoQuebrado,
        Banana,
        Planta
    }
}