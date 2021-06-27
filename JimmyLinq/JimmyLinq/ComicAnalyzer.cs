using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmyLinq
{
    static class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(Comic comic)
        {
            if (Comic.Prices[comic.Issue] < 100)
            {
                return PriceRange.Cheap;
            }

            return PriceRange.Expensive;
        }

        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            var groupedComics = 
                from comic in comics
                orderby prices[comic.Issue]
                group comic by CalculatePriceRange(comic) into PriceGroup
                select PriceGroup;

            return groupedComics;
        }

        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
        {
            var reviewedComics =
                from comic in comics
                orderby comic.Issue
                join review in reviews
                on comic.Issue equals review.Issue
                select $"{review.Critic} rated {comic.Issue} '{comic.Name}' {review.Score}";

            return reviewedComics;
        }
    }
}
