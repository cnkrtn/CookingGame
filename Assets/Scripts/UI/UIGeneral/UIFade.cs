using Core.EventService.Events;
using Core.EventService.Interface;
using Core.EventService.Keys;
using Core.EventService.Service;
using Core.UIService.Interface;
using Core.UIService.Keys;
using Core.UIService.Service;
using DG.Tweening;
using UI.Abstract;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIFade : UIScreen
    {
        [SerializeField] private Image _image;
        private IUIService _uIService;
        public override string ScreenName { get; set; } = UIKeys.KEY_FADE_UI;
        protected override bool SetOnUI { get; set; } = false;
        
        protected override bool Sortable { get; set; } = false;


        protected override void Awake()
        {
            base.Awake();
            _uIService = ReferenceLocator.Instance.UIService;
            EventService.Subscribe<OnFadeStart>(EventKeys.EVENT_ON_FADE_START,OnFadeStart);
        }

        private void OnFadeStart(OnFadeStart obj)
        {
            if(obj.Start)
                FadeStart();
        }

        private void FadeStart()
        {
            DOVirtual.Float(0f, 1f, 0.25f, (value) =>
            {
                _image.color = new Color(0, 0, 0, value);

            }).OnComplete(FadeOut);
        }

        private void FadeOut()
        {
            DOVirtual.Float(1f, 0f, 0.25f, (value) =>
            {
                _image.color = new Color(0, 0, 0, value);
            }).OnComplete(RemoveScreen);
          
        }

        private void RemoveScreen()
        {
            EventService.Fire(EventKeys.EVENT_ON_FADE_START,new OnFadeStart(false));
            _uIService.RemoveFadeScreen();
        }
       
    }
}
