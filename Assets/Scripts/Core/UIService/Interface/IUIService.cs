using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Core.UIService.Interface
{
    public interface IUIService
    {
        void RemoveFadeScreen();
        void ShowFadeScreen();
        Task Inject();
        void ShowLoadingScreenSmall();
        void RemoveLoadingScreenSmall();
        void ShowLoadingScreen();
        void RemoveLoadingScreen();
        void FinishOrder();
        Task<int> ShowSlider(int maxValue,int currentValue);
        Task ShowScreenOrder<T>(string key, T initData);
        Task<GameObject> ShowScreen(string key);
        Task ShowScreen<T>(string key,T data);
        Task ShowScreen<T,T2>(string key,T data,T2 extraData);
        Task ShowScreen<T,T2,T3>(string key,T data,T2 extraData,T3 extraPlusData);
        Task<bool> ShowReturnPopUpScreen(string text);
        void ShowPopUpScreen(string text);
        void RemoveScreen(string screenKey);
        void RemoveAllScreens();
        void AddOnUI();
        void RemoveOnUI();
        void AddSortOrder(bool add);
        int SortOrder { get; }
    }
}
