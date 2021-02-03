using System.ComponentModel.DataAnnotations;

namespace Queridometro.Core.Entities
{
    public enum Emoji
    {
        Amo,
        Odeio,
        Deboche,
        [Display(Name = "Tanto Faz")]
        TantoFaz,
        Nojo,
        Falsiane
    }
}