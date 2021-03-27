using System.ComponentModel.DataAnnotations;

namespace BlackJack
{
    public enum CardSuit
    {
        [Display(Name="C")]
        Clubs,
        
        [Display(Name="D")]
        Diamonds,
        
        [Display(Name="H")]
        Hearts,
        
        [Display(Name = "S")]
        Spades
    }
}