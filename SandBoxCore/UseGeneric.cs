namespace SandBoxCore
{
    internal class UseGeneric
    {
        public void Play()
        {
            var gp = new GenericPlay();
            const int bla = 7;

            // these are the same since the compiler implies the type from the second parameter on the first call.
            gp.IsThing("yo", bla, 7);
            gp.IsThing("yo", bla, 7);
        }
    }
}