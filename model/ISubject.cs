namespace BlackJack.model
{
    public interface ISubject
    {
        void NotifySubs();
        void Subscribe(IObserver sub);
        // void Unsubscribe(IObserver sub);
    }
}