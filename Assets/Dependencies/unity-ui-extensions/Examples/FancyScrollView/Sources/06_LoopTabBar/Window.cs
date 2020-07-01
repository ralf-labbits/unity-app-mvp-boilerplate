namespace UnityEngine.UI.Extensions.Examples.FancyScrollViewExample06
{
    public class Window : MonoBehaviour
    {
        [SerializeField] SlideScreenTransition transition = default;

        public void In(MovementDirection direction)
        {
            if (transition != null)
            {
                transition.In(direction);
            }
        }

        public void Out(MovementDirection direction)
        {
            if (transition != null)
            {
                transition.Out(direction);
            }
        }
    }
}