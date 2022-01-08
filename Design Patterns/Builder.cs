using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class Builder
    {
        //take the constrction part of a thing and sperate it from ites representation
        public static void Run()
        {
            //QueryBuilder builder = new QueryBuilder();
            FormBodyBuilder builder = new FormBodyBuilder();
            ConstructionProcess(builder);
            Console.WriteLine(builder.Build());
        }
        public static void ConstructionProcess(IKeyValueCollectionBuilder builder)
        {
            builder.Add("a"," b").Add("c","d").Add("e","f");
        }
    }
    public interface IKeyValueCollectionBuilder
    {
        IKeyValueCollectionBuilder Add(string key, string value);
    }

    public class QueryBuilder : IKeyValueCollectionBuilder
    {
        private StringBuilder queryStringBuilder = new StringBuilder();
        public IKeyValueCollectionBuilder Add(string key, string value)
        {
            queryStringBuilder.Append(queryStringBuilder.Length == 0 ? "?" : "&");
            queryStringBuilder.Append(key);
            queryStringBuilder.Append("=");
            queryStringBuilder.Append(Uri.EscapeDataString(value));
            return this;
        }

        public String Build()
        {
            return queryStringBuilder.ToString();
        }
    }

    class FormBodyBuilder : IKeyValueCollectionBuilder
    {
        private StringBuilder formBodyBuilder = new StringBuilder();
        public IKeyValueCollectionBuilder Add(string key, string value)
        {
            formBodyBuilder.Append(key);
            formBodyBuilder.Append(":");
            formBodyBuilder.Append(value);
            formBodyBuilder.Append(Environment.NewLine);
            return this;
        }
        public String Build()
        {
            return formBodyBuilder.ToString();
        }
    }

}
