
using Core.EventService.Events;
using Core.EventService.Interface;
using Core.EventService.Keys;
using Core.UIService.Interface;
using UnityEngine;

namespace UI.Abstract
{
    public abstract class UIScreen : MonoBehaviour
    {
        protected IEventService EventService;
        protected IUIService UIService;
       

        public abstract string ScreenName { get; set; }
        protected abstract bool SetOnUI { get; set; }
        protected abstract bool Sortable { get; set; }
        private Canvas Canvas { get; set; }

        
        protected virtual void Awake()
        {
            UIService = ReferenceLocator.Instance.UIService;
            EventService = ReferenceLocator.Instance.EventService;
            if(TryGetComponent<Canvas>(out var canvas))
            {
                Canvas = canvas;
            }
        }

        public virtual void OnEnable()
        {
            if (SetOnUI)
            {
                UIService.AddOnUI();
                if (Sortable)
                {
                    UIService.AddSortOrder(true);
                    Canvas.sortingOrder = UIService.SortOrder;
                }
            }
        }

        public virtual void OnDisable()
        {
            if (SetOnUI)
            {
                UIService.RemoveOnUI();
                if(Sortable)
                    UIService.AddSortOrder(false);
            }
        }
        
    }
    public abstract class UIScreen<T> : MonoBehaviour
    {
        private Canvas _canvas;
        protected IEventService EventService;
        public abstract string ScreenName { get; set; }
        protected abstract bool SetOnUI { get; set; }
        protected abstract bool Sortable { get; set; }

        protected IUIService UIService;
      
        
        protected abstract void OnUIInit(OnUIInit<T> obj);

        protected virtual void Awake()
        {
            EventService = ReferenceLocator.Instance.EventService;
          
            UIService = ReferenceLocator.Instance.UIService;
            if(TryGetComponent<Canvas>(out var canvas))
            {
                _canvas = canvas;
            }
        }

        protected void UnSubscribe()
        {
            EventService.UnSubscribe<OnUIInit<T>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
        }

        public virtual void OnEnable()
        {
            EventService.Subscribe<OnUIInit<T>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
            UIService = ReferenceLocator.Instance.UIService;
            IUIService uIService = ReferenceLocator.Instance.UIService;
            if (SetOnUI)
            {
                uIService.AddOnUI();
                if (Sortable)
                {
                    UIService.AddSortOrder(true);
                    _canvas.sortingOrder = UIService.SortOrder;
                }
            }
        }

        public virtual void OnDisable()
        {
            EventService.UnSubscribe<OnUIInit<T>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
            IUIService uIService = ReferenceLocator.Instance.UIService;
            if (!SetOnUI) return;
            uIService.RemoveOnUI();
            if(Sortable) UIService.AddSortOrder(false);
        }
    }
    public abstract class UIScreen<T,T2> : MonoBehaviour
    {
        
        private Canvas _canvas;

        protected IEventService EventService;
        public abstract string ScreenName { get; set; }
        protected abstract bool SetOnUI { get; set; }
        protected abstract bool Sortable { get; set; }
        
        protected IUIService UIService;
        
      
        protected abstract void OnUIInit(OnUIInit<T,T2> obj);
        
        protected virtual void Awake()
        {
            EventService = ReferenceLocator.Instance.EventService;
            if(TryGetComponent<Canvas>(out var canvas))
            {
                _canvas = canvas;
            }
        }

        protected void UnSubscribe()
        {
            EventService.UnSubscribe<OnUIInit<T,T2>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
        }
   
        public virtual void OnEnable()
        {
            EventService.Subscribe<OnUIInit<T,T2>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
            UIService = ReferenceLocator.Instance.UIService;
            IUIService uIService = ReferenceLocator.Instance.UIService;
            if (SetOnUI)
            {
                uIService.AddOnUI();
                if (Sortable)
                {
                    UIService.AddSortOrder(true);
                    _canvas.sortingOrder = UIService.SortOrder;
                }
            }
        }

        protected virtual void OnDisable()
        {
            EventService.UnSubscribe<OnUIInit<T,T2>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
            IUIService uIService = ReferenceLocator.Instance.UIService;
            if (SetOnUI)
            {
                uIService.RemoveOnUI();
                if(Sortable)
                    UIService.AddSortOrder(false);
            }
        }
    }
    
    public abstract class UIScreen<T,T2,T3> : MonoBehaviour
    {
        private Canvas _canvas;

        protected IEventService EventService;
        public abstract string ScreenName { get; set; }
        protected abstract bool SetOnUI { get; set; }
        protected abstract bool Sortable { get; set; }
        
        protected IUIService UIService;
        
       
        protected abstract void OnUIInit(OnUIInit<T,T2,T3> obj);
        
        protected virtual void Awake()
        {
            EventService = ReferenceLocator.Instance.EventService;
            if(TryGetComponent<Canvas>(out var canvas))
            {
                _canvas = canvas;
            }
        }

        protected void UnSubscribe()
        {
            EventService.UnSubscribe<OnUIInit<T,T2,T3>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
        }
   
        public virtual void OnEnable()
        {
            EventService.Subscribe<OnUIInit<T,T2,T3>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
            UIService = ReferenceLocator.Instance.UIService;
            IUIService uIService = ReferenceLocator.Instance.UIService;
            if (SetOnUI)
            {
                uIService.AddOnUI();
                if (Sortable)
                {
                    UIService.AddSortOrder(true);
                    _canvas.sortingOrder = UIService.SortOrder;
                }
            }
        }

        protected virtual void OnDisable()
        {
            EventService.UnSubscribe<OnUIInit<T,T2,T3>>(EventKeys.EVENT_ON_UI_INIT,OnUIInit);
            IUIService uIService = ReferenceLocator.Instance.UIService;
            if (SetOnUI)
            {
                uIService.RemoveOnUI();
                if(Sortable)
                    UIService.AddSortOrder(false);
            }
        }
    }
}
