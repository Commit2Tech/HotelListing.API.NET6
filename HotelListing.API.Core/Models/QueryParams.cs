namespace HotelListing.API.Core.Models
{
    public class QueryParams
    {
        private int _pageSize = 15;
        private int _pageNumber = 1;
      
        public int PageNumber {
            get { return _pageNumber; }
            set { _pageNumber = value; } 
        }
        public int PageSize 
        { 
            get { return _pageSize; }
            set { _pageSize = value; } 
        }
    }
}
