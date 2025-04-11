using Core.GameService.Interface;
using Core.UIService.Interface;
using UI.Abstract;
using UnityEngine;
using UnityEngine.UI;

public class UISettingsScreen : UIScreen
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;

    private IGameService _gameService;
    private IUIService _uiService;

    public override string ScreenName { get; set; } = Core.UIService.Keys.UIKeys.KEY_SETTINGS_UI;
    protected override bool SetOnUI { get; set; } = true;
    protected override bool Sortable { get; set; } = true;

    protected override void Awake()
    {
        base.Awake();

        _gameService = ReferenceLocator.Instance.GameService;
        _uiService = ReferenceLocator.Instance.UIService;

        _playButton.onClick.AddListener(() =>
        {
            
        });

        _settingsButton.onClick.AddListener(() =>
        {
            _uiService.RemoveScreen(Core.UIService.Keys.UIKeys.KEY_SETTINGS_UI);
            _uiService.ShowScreen(Core.UIService.Keys.UIKeys.KEY_MAIN_MENU_UI);
        });
    }
}

