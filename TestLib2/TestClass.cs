using AnnotationLib;

namespace TestLib2
{
    [Changed("02/02/2016", "A. Jelesin", "Test Class 2")]
    public class TestClass2
    {

        [Changed("03/02/2016", "A. Jelesin", "Fix some problems - 3")]
        public long TestMethod(int a, int b)
        {
            return (long)a - (long)b;
        }
    }
}
