using AnnotationLib;

namespace OtherLib
{
    [Changed("02/02/2016", "A. Jelesin", "Test class 1")]
    public class TestClass1
    {

        [Changed("03/02/2016", "A. Jelesin", "Fix some problems - 3")]
        public long TestMethod(int a, int b)
        {
            return (long) a + (long) b;
        }
    }
}
