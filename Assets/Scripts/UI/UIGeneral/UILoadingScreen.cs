
using Core.UIService.Keys;
using TMPro;
using UI.Abstract;
using UnityEngine;

namespace UI
{
    public class UILoadingScreen : UIScreen
    {
        public override string ScreenName { get; set; } = UIKeys.KEY_LOADING_SCREEN_UI;
        protected override bool SetOnUI { get; set; } = true;
        protected override bool Sortable { get; set; } = false;
        
        [SerializeField] private TextMeshProUGUI _text;

        protected override void Awake()
        {
            base.Awake();
           // _text.text = ReferenceLocator.Instance.LanguageService.GetWord(LanguageKeys.Loading);
        }
    }
}
