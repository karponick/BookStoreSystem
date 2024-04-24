using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreSystem
{
    public class Review
    {
        /**************************** Fields *******************************************/
        private int id, userId, bookId, styleRating, plotRating, characterRating;
        private string description, submissionDateTime, lastEditDateTime;

        /**************************** Constructor *******************************************/
        public Review(string userIdString, string bookIdString)
        {
            int.TryParse(userIdString, out userId);
            int.TryParse(bookIdString, out bookId);
        }
        /**************************** Properties *******************************************/
        public int Id { get { return id; } set { id = value; } }
        public int UserId { get { return userId; } }
        public int BookId { get { return bookId; } }
        public string Description { get { return description; } set {  description = value; } }
        public int StyleRating { get { return styleRating; } set { styleRating = value; } }
        public int PlotRating { get { return plotRating; } set {  plotRating = value; } }
        public int CharacterRating { get { return characterRating; } set { characterRating = value; } }
        public string SubmissionDateTime { get { return submissionDateTime; } set { submissionDateTime = value; } }
        public string LastEditDateTime { get { return lastEditDateTime; } set { lastEditDateTime = value; } }
        /**************************** Methods *******************************************/
        public void SetRatings (string style, string plot, string character)
        {
            int.TryParse(style, out styleRating);
            int.TryParse(plot, out plotRating);
            int.TryParse(character, out characterRating);
        }
    }
}
