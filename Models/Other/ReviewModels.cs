using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Models.Other
{
    public class AddReviewModel
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public string ReviewText { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public ReviewRating Rating { get; set; }
    }

    // Other models for handling reviews
}
