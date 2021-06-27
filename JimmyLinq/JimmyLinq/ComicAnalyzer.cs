using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JimmyLinq
{
    public static class ComicAnalyzer
    {
        private static PriceRange CalculatePriceRange(Comic comic, IReadOnlyDictionary<int, decimal> prices)
        {
            if (prices[comic.Issue] < 100)
            {
                return PriceRange.Cheap;
            }

            return PriceRange.Expensive;
        }

        public static IEnumerable<IGrouping<PriceRange, Comic>> GroupComicsByPrice(IEnumerable<Comic> comics, IReadOnlyDictionary<int, decimal> prices)
        {
            //var groupedComics = 
            //    from comic in comics
            //    orderby prices[comic.Issue]
            //    group comic by CalculatePriceRange(comic, prices) into PriceGroup
            //    select PriceGroup;

            var groupedComics = comics.OrderBy(x => prices[x.Issue])
                .GroupBy(x => CalculatePriceRange(x, prices));


            return groupedComics;
        }

        public static IEnumerable<string> GetReviews(IEnumerable<Comic> comics, IEnumerable<Review> reviews)
        {
            //var reviewedComics =
            //    from comic in comics
            //    orderby comic.Issue
            //    join review in reviews
            //    on comic.Issue equals review.Issue
            //    select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";

            var reviewedComics =
                comics.OrderBy(x => x.Issue)
                .Join(reviews, // sequence to join
                        comic => comic.Issue, // on part of join
                        review => review.Issue, // equals part of join
                        (comic, review) => // two parameters and returns select output
                        $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}");
                

            return reviewedComics;
        }
    }
}
