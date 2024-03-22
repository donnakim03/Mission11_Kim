namespace Mission11_Kim.Models.ViewModels
{
    public class PaginationInfo
    {
        public int TotalItems { get; set; } // total items in database
        public int ItemsPerPage { get; set; } // items that you want to hold per page
        public int CurrentPage { get; set; } // the current page user is on
        public int TotalNumPages => (int)(Math.Ceiling((decimal) TotalItems / ItemsPerPage)); // calculation that always rounds up to figure out the necessary number of pages
    }
}
