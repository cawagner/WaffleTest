namespace WaffleTest
{
    public sealed class VoidType
    {
        public static readonly VoidType Value = new VoidType();

        private VoidType()
        {
        }

        public override string ToString()
        {
            return "Void";
        }
    }
}