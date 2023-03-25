using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class AsyncSceneLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private Image _loadingImage;
    [SerializeField] private TextMeshProUGUI _loadingText;

    private void Start()
    {
        float progress = Mathf.Clamp01(0.0f);
        if(_loadingImage != null)
            _loadingImage.fillAmount = progress;
        if (_loadingText != null)
            _loadingText.text = "";

    }

    public void StartGame()
    {
        
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneName);

        while (!asyncLoad.isDone)
        {
            if(_loadingImage != null && _loadingText != null)
            {
                float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
                _loadingImage.fillAmount = progress;
                _loadingText.text = $"Loading... {progress * 100f}%";
            }
           

            yield return new WaitForEndOfFrame();
        }
    }
}
