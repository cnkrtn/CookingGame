using Core.AddressableService.Interface;
using Core.AddressableService.Service;
using Core.AudioService;
using Core.AudioService.Interface;
using Core.AudioService.Keys;
using Core.AudioService.Service;
using Core.EventService.Interface;
using Core.EventService.Service;
using Core.GameService.Interface;
using Core.GameService.Service;
using Core.SceneLoaderService.Interface;
using Core.SceneLoaderService.Keys;
using Core.SceneLoaderService.Service;
using Core.UIService.Interface;
using Core.UIService.Keys;
using Core.UIService.Service;
using UnityEngine;
using UnityEngine.Audio;

public class ReferenceLocator : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private AudioSource _audioSource1;
    [SerializeField] private AudioSource _audioSource11;
    [SerializeField] private AudioSource _audioSource12;
    [SerializeField] private AudioSource _musicSource;

    public static ReferenceLocator Instance;

    private IAudioService _audioService;
    private IUIService _uiService;
    private ISceneLoaderService _sceneLoaderService;
    private IAddressableService _addressableService;
    private IEventService _eventService;
    private IGameService _gameService;

    public IAudioService AudioService => _audioService;
    public IUIService UIService => _uiService;
    public ISceneLoaderService SceneLoaderService => _sceneLoaderService;
    public IAddressableService AddressableService => _addressableService;
    public IEventService EventService => _eventService;
    public IGameService GameService => _gameService;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Instance = this;

        _audioService = new AudioService();
        _uiService = new UIService();
        _sceneLoaderService = new SceneLoaderService();
        _addressableService = new AddressableService();
        _eventService = new EventService();
        _gameService = new GameService();

      //  SoundSettingsManager.Initialize(_audioMixer);

        Init();
    }

    private async void Init()
    {
        await _audioService.Inject(_audioSource1, _audioSource12, _audioSource11, _musicSource);
        await _addressableService.Inject();
        await _gameService.Inject();
        await _eventService.Inject();
        await _uiService.Inject();
        await _sceneLoaderService.Inject();

        StartGame();
    }

    private async void StartGame()
    {
        await _sceneLoaderService.LoadScene(SceneKeys.KEY_MAIN_MENU_SCENE);
        await _uiService.ShowScreen(UIKeys.KEY_MAIN_MENU_UI);
      //  _audioService.PlayMusic(AudioKeys.KEY_MAIN_MUSIC, 1000);
    }

    private void Update()
    {
        if (_gameService.GameReady)
        {
            // Optional per-frame logic here (like calling Update() on other systems)
        }
    }
}
