using UniRx;

namespace JobTest.Killable
{
    public interface IKillable
    {
        ReactiveProperty<bool> Dead { get; }
        void Kill();
    }
}