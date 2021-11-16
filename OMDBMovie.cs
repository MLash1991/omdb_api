namespace OMDBAPI
{
    public class OMDBMovie
    {
        public string Title { get; set; }

        public int Year { get; set; } 

        public string Rated { get; set; } 

        public List<Rating> Ratings { get; set; }

    }
    
    


    public class Rating
    {
        public string Source { get; set; } 

        public string Value { get; set; } 

       
    }
}