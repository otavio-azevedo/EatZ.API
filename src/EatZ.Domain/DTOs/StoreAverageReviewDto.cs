namespace EatZ.Domain.DTOs
{
    public class StoreAverageReviewDto
    {
        public StoreAverageReviewDto()
        {
            AverageRating = 5;
        }

        public StoreAverageReviewDto(string storeId, double averageRating, int numberOfReviews)
        {
            StoreId = storeId;
            AverageRating = averageRating;
            NumberOfReviews = numberOfReviews;
        }

        public string StoreId { get; private set; }
        public double AverageRating { get; private set; }
        public int NumberOfReviews { get; private set; }
    }
}