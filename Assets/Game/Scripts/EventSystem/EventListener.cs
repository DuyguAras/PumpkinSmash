namespace Core.Games.GameName.EventBus
{
    public delegate void EventListener<in TEvent>(object sender, TEvent @event);
}