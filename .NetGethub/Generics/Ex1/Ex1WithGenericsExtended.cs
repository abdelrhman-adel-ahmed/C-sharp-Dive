using Generics.Ex1.WithGenerics;
using System.Xml.Linq;

namespace Generics.Ex1.WithGenericsExtended
{
    public class Ex1WithGenericsExtended
    {
        public static void Run()
        {
            Console.WriteLine("Ex1WithGenericsExtended");
            Hasher.Hash(new Comment());
            Hasher.Hash(new Post());
        }
    }
    public interface IHashingStrategy
    {
        int Hash(Content content);
    }
    public abstract class HashingStrategy<T> : IHashingStrategy where T : Content
    {
        public int Hash(Content content) => Hash((T)content);
        protected abstract int Hash(T content);
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
    public class PostHashingStrategy : HashingStrategy<Post>
    {
        protected override int Hash(Post content)
        {
            return content.Text.Length + content.Author.Length;
        }
    }
    public class CommentHashingStrategy : HashingStrategy<Comment>
    {
        protected override int Hash(Comment content)
        {
            return content.Text.Length + content.Author.Length + content.PostId.Length;
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
