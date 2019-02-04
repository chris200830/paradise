using Unity;

namespace Player
{
    internal static class Initializer
    {
        public static UnityContainer UnityContainer { get; private set; }

        public static void Initialize(UnityContainer unityContainer)
        {
            UnityContainer = unityContainer;
        }
    }
}
