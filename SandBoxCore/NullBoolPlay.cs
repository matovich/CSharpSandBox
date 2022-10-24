namespace SandBoxCore
{
    public class NullBoolPlay
    {
        public bool LoadBool()
        {
            var testObject = new MyFunction();
            var o = new object();
            bool myBool = false;
            try
            {
                // myBool = (bool)testObject;
                return myBool;
            }
            catch
            {
                return true;
            }
        }
    }
}