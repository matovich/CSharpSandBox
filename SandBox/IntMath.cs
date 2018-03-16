namespace SandBox
{
    public class IntMath
    {
        public int GetHundreds(int i)
        {
            return i / 100;
        }

        public bool IsEvenHundreds(int i)
        {
            int i1 = i / 100 % 2;
            return i1 < 1;
        }
    }
}