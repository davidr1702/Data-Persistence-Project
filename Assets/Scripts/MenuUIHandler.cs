using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public GameObject inputPlayerName;
    public TextMeshProUGUI BestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = $"Best Score: {MainInstance.Instance.BestScorePlayer}: {MainInstance.Instance.BestScore}";
    }

    private void Update()
    {
        MainInstance.Instance.CurrentPlayer = inputPlayerName.GetComponent<TMP_InputField>().text;
        Debug.Log(inputPlayerName.GetComponent<TMP_InputField>().text);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit(); // original code to quit Unity player
        #endif
    }
}
