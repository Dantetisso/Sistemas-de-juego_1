    public static class Cloner
    {
        public static ICloneable CloneObject(ICloneable clonable)
        {
            var newClone = clonable.Clone();
            return newClone;
        }
    }

   