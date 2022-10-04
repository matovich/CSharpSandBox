namespace SandBox
{
    public class IntMath
    {
        public int GetHundreds(int i)
        {
            return i / 100;
        }

        /// <summary>
        /// Returns true if the 100's placeholder is even.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool IsEvenHundreds(int i)
        {
            int i1 = i / 100 % 2;
            return i1 < 1;
        }
    }
}