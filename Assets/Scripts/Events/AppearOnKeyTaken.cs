using JobTest.Misc;
using UniRx;

namespace JobTest.Events
{
    public class AppearOnKeyTaken : EventConditionAppear
    {
        public void Set(Key key)
        {
            key.Collected.Subscribe((value) =>
            {
                if (value)
                    Appear();
            }).AddTo(key);
        }
    }
}