using System.ComponentModel.DataAnnotations;

namespace BlackJack
{
    public enum CardRank
    {
        [Display(Name="2", Order = 1)]
        Two,
        
        [Display(Name="3", Order = 2)]
        Three,
        
        [Display(Name="4", Order = 3)]
        Four,
        
        [Display(Name="5", Order = 4)]
        Five,
        
        [Display(Name="6", Order = 5)]
        Six,
        
        [Display(Name="7", Order = 6)]
        Seven,
        
        [Display(Name="8", Order = 7)]
        Eight,
        
        [Display(Name="9", Order = 8)]
        Nine,
        
        [Display(Name="10", Order = 9)]
        Ten,
        
        [Display(Name="J", Order = 10)]
        Jack,
        
        [Display(Name="Q", Order = 11)]
        Queen,
        
        [Display(Name="K", Order = 12)]
        King,
        
        [Display(Name="A", Order = 13)]
        Ace
        
        
    }
}