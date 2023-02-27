using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Ex1.WithoutGenerics
{
    public class Ex1WithoutGenerics
    {
        //problem here when ever we add new drived type from Content
        //we need to add one more line in the factory to commidate the creation of 
        //the hasher of that new type
        public static void Run()
        {
            Console.WriteLine("Ex1WithoutGenerics");
            Hasher.Hash(new Comment());
            Hasher.Hash(new Post());
        }
    }
    public class Content
    {
        public string Id { get; set; } = "Id";
        public string Author { get; set; } = "Author";
        public string Text { get; set; } = "Tex";
    }
    public class Post : Content { }
    public class Comment : Content
    {
        public string PostId { get; set; } = "postid";
    }
    public class PostHashingStrategy
    {
        public static int Hash(Post post) => post.Text.Length + post.Author.Length;
    }
    public class CommmentHashingStrategy
    {
        public static int Hash(Comment comment)
            => comment.Text.Length + comment.Author.Length + comment.PostId.Length;
    }

    public class Hasher
    {
        public static int Hash(Content content)
        {
            if (content is Post p) return PostHashingStrategy.Hash(p);
            if (content is Comment c) return CommmentHashingStrategy.Hash(c);
            return 0;
        }
    }
}
