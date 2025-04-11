using System;
using System.Threading.Tasks;

namespace Core.EventService.Interface
{
    public interface IEventService
    {
        Task Inject();
        void Subscribe<T>(byte evtName, Action<T> listener);
        void UnSubscribe<T>(byte evtName, Action<T> listener);
        void Fire<T>(byte evtName, T data);
    }
}