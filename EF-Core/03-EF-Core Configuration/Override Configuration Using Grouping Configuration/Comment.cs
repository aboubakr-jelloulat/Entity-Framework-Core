namespace _03_EF_Core_Configuration.Override_Configuration_Using_Grouping_Configuration
{
    internal partial class clsOverrideConfigurationUsingGroupingConfiguration
    {
        public class Comment
        {
            public int CommentId { get; set; }
            public int TweetId { get; set; }
            public int UserId { get; set; }
            public string CommentText { get; set; }
            public DateTime CreatedAt { get; set; }
        }


    }
}
