using UnityEngine;
using UnityEngine.Events;

namespace CoinSystem
{
    public class Coin : MonoBehaviour
    {
        public static Coin instance;

        public int playerCoins;

        private UnityEvent<int> OnCoinsChanged = new UnityEvent<int>();

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);

                if (PlayerPrefs.HasKey("PlayerCoins"))
                {
                    playerCoins = PlayerPrefs.GetInt("PlayerCoins");
                }
                else
                {
                    playerCoins = 0;
                    SavePlayerCoins();
                }
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void AddCoins(int amount)
        {
            playerCoins += amount;

            OnCoinsChanged?.Invoke(playerCoins);
            SavePlayerCoins();
        }

        public bool RemoveCoins(int amount)
        {
            if (playerCoins >= amount)
            {
                playerCoins -= amount;

                OnCoinsChanged?.Invoke(playerCoins);
                SavePlayerCoins();

                return true;
            }

            return false;
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SavePlayerCoins();
            }
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                SavePlayerCoins();
            }
        }

        private void SavePlayerCoins()
        {
            PlayerPrefs.SetInt("PlayerCoins", playerCoins);
            PlayerPrefs.Save();
        }
    }
}