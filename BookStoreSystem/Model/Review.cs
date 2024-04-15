using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem
{
    public class Review
    {
        /**************************** Fields *******************************************/
        private int id, userId, bookId, styleRating, plotRating, characterRating;
        private string description;
        private DateTime submissionDateTime;

        /**************************** Constructor *******************************************/
        public Review(string idString, string userIdString, string bookIdString)
        {
            int.TryParse(idString, out id);
            int.TryParse(userIdString, out userId);
            int.TryParse(bookIdString, out bookId);
            submissionDateTime = DateTime.UtcNow;
        }
        /**************************** Properties *******************************************/
        public int Id { get { return id; } }
        public int UserId { get { return userId; } }
        public int BookId { get { return bookId; } }
        public string Description { get { return description; } set {  description = value; } }
        public int StyleRating { get { return styleRating; } set { styleRating = value; } }
        public int PlotRating { get { return plotRating; } set {  plotRating = value; } }
        public int CharacterRating { get { return characterRating; } set { characterRating = value; } }
        public DateTime SubmissionDateTime { get { return submissionDateTime; } }
        /**************************** Methods *******************************************/
        public void SetRatings (string style, string plot, string character)
        {
            int.TryParse(style, out styleRating);
            int.TryParse(plot, out plotRating);
            int.TryParse(character, out characterRating);
        }
        public string[] ToArray()
        {
            //"Username";
            //"Book Title";
            //"Description";
            //"Style Rating";
            //"Plot Rating";
            //"Character Rating";
            return new string[]
            {
                "Name", // Username
                DatabaseController.GetBookTitle(bookId),
                description,
                styleRating.ToString(),
                plotRating.ToString(),
                characterRating.ToString(),
            };
        }

    }
}
