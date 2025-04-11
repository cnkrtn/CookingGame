using System.Threading.Tasks;
using Core.EventService.Events;
using Core.EventService.Interface;
using Core.EventService.Keys;
using Core.GameService.Interface;
using Core.SceneLoaderService.Interface;
using Core.SceneLoaderService.Keys;
using Core.UIService.Interface;

namespace Core.GameService.Service
{
    public class GameService : IGameService
    {
        private IEventService _eventService;
        private IUIService _uiService;
        private ISceneLoaderService _sceneLoaderService;

        private bool _onTransition;
        private bool _fading;
        private bool _gameReady;
        private bool _loadingScreen;
        private bool _onUI;

        public bool Fading => _fading;
        public bool GameReady => _gameReady;
        public bool LoadingScreen => _loadingScreen;
        public bool OnUI => _onUI;
        public bool OnTransition => _onTransition;

        public async void SetOnUI(bool value)
        {
            await Task.Delay(20);
            _onUI = value;
        }

        public Task Inject()
        {
            _uiService = ReferenceLocator.Instance.UIService;
            _eventService = ReferenceLocator.Instance.EventService;
            _sceneLoaderService = ReferenceLocator.Instance.SceneLoaderService;

            _eventService.Subscribe<OnFadeStart>(EventKeys.EVENT_ON_FADE_START, OnFadeStart);
            return Task.CompletedTask;
        }

        public void SetLoadingScreen(bool value)
        {
            _loadingScreen = value;
        }

        public async void StartGame()
        {
            _uiService.ShowLoadingScreen();
            await _sceneLoaderService.LoadScene(SceneKeys.KEY_GAME_START_SCENE);
            _gameReady = true;
            await Task.Delay(20);
            _uiService.RemoveLoadingScreen();
        }

        public async void ReturnGame()
        {
            _onTransition = true;
            _gameReady = false;

            _uiService.ShowLoadingScreen();
            await _sceneLoaderService.LoadScene(SceneKeys.KEY_GAME_START_SCENE);

            _gameReady = true;
            _uiService.RemoveLoadingScreen();
            _uiService.RemoveLoadingScreenSmall();

            await Task.Delay(50);
            _onTransition = false;
        }

        private void OnFadeStart(OnFadeStart obj)
        {
            _fading = obj.Start;
        }
    }
}
