namespace QuizAppModelLibrary
{
    public class Quiz
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<QuizQuestion> Questions { get; set; }
        public bool IsPublished { get; set; }
    }
}
