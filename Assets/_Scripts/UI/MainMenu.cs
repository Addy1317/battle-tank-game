using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace BattleTank
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Panel References")]
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject settingsMenuPanel;

        [Header("Button References")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button quitButton;

        [SerializeField] private Button backButton;


        private void Awake()
        {
            
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public void PlayButton()
        {
            SceneManager.LoadScene(1);
        }

        public void SettingButton()
        {
            settingsMenuPanel.gameObject.SetActive(true);
        }

        public void BackButton()
        {
            settingsMenuPanel.gameObject.SetActive(false);
        }

        public void QuitButton()
        {
            Application.Quit();
            Debug.Log("Application has Quit");
        }
    
    }
}
