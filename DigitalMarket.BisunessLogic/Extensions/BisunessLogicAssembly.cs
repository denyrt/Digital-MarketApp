using System.Reflection;

namespace DigitalMarket.BisunessLogic.Extensions
{
    public static class BisunessLogicAssembly
    {
        public static Assembly GetAssembly()
        {
            return typeof(BisunessLogicAssembly).Assembly;
        }
    }
}
