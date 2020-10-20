namespace Entities.AdminSingleTable
{
    public class TableFilms
    {
        public string FilmId { private set; get; }

        public string Title { private set; get; }

        public string Country { private set; get; }
        public string Producer { private set; get; }

        public string Duration { private set; get; }
        public string ReleaseDate { private set; get; }
        public string Genre { private set; get; }

        public string BasePrice { private set; get; }


        public TableFilms(string FilmId, string Title, string Country, string Producer, string Duration, string ReleaseDate, string Genre, string BasePrice)
        {
            this.FilmId = FilmId;

            this.Title = Title;

            this.Country = Country;
            this.Producer = Producer;

            this.Duration = Duration;
            this.ReleaseDate = ReleaseDate;
            this.Genre = Genre;

            this.BasePrice = BasePrice;
        }

        public TableFilms()
        {

        }
    }
}
