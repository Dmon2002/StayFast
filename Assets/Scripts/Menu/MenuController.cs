using System;
using UnityEngine;

namespace StayFast
{
    public class MenuController : BaseController, IDisposable
    {
        private MenuView _view;
<<<<<<< Updated upstream
=======
        private SoundDescriptions _sound;
>>>>>>> Stashed changes

        private bool isPaused = true;

<<<<<<< Updated upstream
        public MenuController(MenuView view, InputController input, MonoFactory factory)
=======
        public MenuController(MenuView view, InputController input, MonoFactory factory, SoundDescriptions sound)
>>>>>>> Stashed changes
        {
            _view = view;
            
            input.OnClickESC += OnClickPaused;
            _view.Resume.onClick.AddListener(OnClickPaused);
            _view.AboutUs.onClick.AddListener(OnClickAboutUs);
            _view.Restart.onClick.AddListener(Restart);
            _view.CloseAbout.onClick.AddListener(CloseAbout);
            _view.CloseAbout.gameObject.SetActive(false);
        }

        private void Restart()
        {
            // todo
            Debug.Log("Мы нажали на рестарт");
        }

        private void OnClickAboutUs()
        {
<<<<<<< Updated upstream
            Debug.Log($"Mы нажали на About Us");
            // todo добавить окно с описанием всех нас
=======
        
            Sounding.PlayAudio(ClipType.Paper);
            
            
>>>>>>> Stashed changes
            _view.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            _view.PanelAboutUs.SetActive(true);
            _view.CloseAbout.gameObject.SetActive(true);
            _view.CloseAbout.onClick.AddListener(CloseAbout);
        }

        private void CloseAbout()
        {
<<<<<<< Updated upstream
=======
            Sounding.PlayAudio(ClipType.Paper);
            
>>>>>>> Stashed changes
            _view.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            _view.PanelAboutUs.SetActive(false);
            _view.CloseAbout.gameObject.SetActive(false);
        }

        public void OnClickPaused()
        {
<<<<<<< Updated upstream
            Debug.Log($"{isPaused}");
=======
            Sounding.PlayAudio(ClipType.Paper);
>>>>>>> Stashed changes
            
            switch (isPaused)
            {
                case false:
                    Debug.Log($"Мы открываем меню");
                    OpenPauseMenu();
                    return;
                case true:
                    Debug.Log($"Мы закрываем меню");
                    ClosePauseMenu();
                    break;
            }
        }
        
        private void OpenPauseMenu()
        {
<<<<<<< Updated upstream
            // todo возможно делаем ещё какие-то дела
=======
            Sounding.PlayAudio(ClipType.Paper);
            
>>>>>>> Stashed changes
            _view.gameObject.SetActive(true);
            Time.timeScale = 0;
            isPaused = true;
            
        }
          
        private void ClosePauseMenu()
        {
<<<<<<< Updated upstream
=======
            Sounding.PlayAudio(ClipType.Paper);
            
>>>>>>> Stashed changes
            Debug.Log("Мы зашли в закрывашку");
            _view.gameObject.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }

        protected override void OnDispose()
        {
            _view.Resume.onClick.RemoveAllListeners();
            _view.Restart.onClick.RemoveAllListeners();
            _view.AboutUs.onClick.RemoveAllListeners();
            _view.CloseAbout.onClick.RemoveAllListeners();
        }
    }
}