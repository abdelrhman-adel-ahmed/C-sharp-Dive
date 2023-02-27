namespace Generics.Ex1.WithGenerics
{
    public class Ex2WithGenerics
    {
        //now due to generic we can inforce type checking with IHashingStrategy , 
        //along with dynamically creating the hash strategy 
        //The problem is IHashingStrategy hash function take the base type explicily
        //so you have to convert it in the corresponding hash function to the desired type
        public static void Run()
        {
            Console.WriteLine("Ex2WithGenerics");
            Hasher.Hash(new Comment());
            Hasher.Hash(new Post());
        }
    }
    public interface IHashingStrategy
    {
        int Hash(Content content);
    }
    public class Content
    {
        public string Id { get; set; } = "Id";
        public string Author { get; set; } = "Author";
        public string Text { get; set; } = "Tex";
    }
    public class Content<T> : Content where T : IHashingStrategy { }
    public class Post : Content<PostHashingStrategy> { }
    public class Comment : Content<CommentHashingStrategy>
    {
        public string PostId { get; set; } = "postid";
    }
    public class PostHashingStrategy : IHashingStrategy
    {
        public int Hash(Content content)
        {
            var post = content as Post;
            return post.Text.Length + post.Author.Length;
        }
    }
    public class CommentHashingStrategy : IHashingStrategy
    {
        public int Hash(Content content)
        {
            var comment = content as Comment;
            return comment.Text.Length + comment.Author.Length + comment.PostId.Length;
        }
    }

    public class Hasher
    {
        public static int Hash<T>(Content<T> content)
            where T : IHashingStrategy, new()
        {
            return Activator.CreateInstance<T>().Hash(content);
        }
    }
}
