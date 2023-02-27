using System.ComponentModel.DataAnnotations;

namespace WebApiCore
{
    public class TestModel
    {
        [MaxLength(10)]
        public long N { get; set; }
    }
}
