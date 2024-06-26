using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchLog : MonoBehaviour
{
    public Text logText;  // UIのTextコンポーネントをアタッチする
    private string logContent = "";

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string logString, string stackTrace, LogType type)
    {
        string color;

        switch (type)
        {
            case LogType.Error:
            case LogType.Exception:
                color = "red";
                break;
            case LogType.Warning:
                color = "yellow";
                break;
            default:
                color = "white";
                break;
        }

        string formattedMessage = $"<color={color}>{type}: {logString}\n{stackTrace}</color>";
        logContent += formattedMessage + "\n";
        logText.text = logContent;

        // スクロールビューの自動スクロール
        Canvas.ForceUpdateCanvases();
        logText.GetComponentInParent<ScrollRect>().verticalNormalizedPosition = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("スペースキーが押されました");
        }
    }
}
