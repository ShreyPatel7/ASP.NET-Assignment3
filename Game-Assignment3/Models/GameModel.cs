using System.ComponentModel.DataAnnotations;

namespace Game_Assignment3.Models
{
    public class GameModel
    {
        [Key]
        // This property is marked as the primary key for the table
        public required int Id { get; set; }

        // This property represents the 'Title' column in the table
        public required string Title { get; set; }

        // This property represents the 'Genre' column in the table
        public required string Genre { get; set; }

        // This property represents the 'ReleaseDate' column in the table
        public required DateTime ReleaseDate { get; set; }

        // This property represents the 'Price' column in the table
        public required decimal Price { get; set; }
    }
}
