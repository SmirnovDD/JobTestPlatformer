namespace JobTest.Events
{
    public class EventConditionAppear : EventCondition
    {
        private IAppear _appear;
        private void Awake()
        {
            _appear = GetComponent<IAppear>();
        }

        protected void Appear()
        {
            _appear?.Appear();
        }
    }
}