namespace Core.EventService.Events
{
    public class OnFadeStart
    {
        public bool Start;
        public OnFadeStart(bool start)
        {
            Start = start;
        }
    }
}