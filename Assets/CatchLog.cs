using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchLog : MonoBehaviour
{
    public Text logText;  // UIのTextコンポーネントをアタッチする
    private string logContent = "";
    private const int maxLines = 2;

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
        if (logText == null)
        {
            Debug.LogError("logText is not assigned.");
            return;
        }

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
        
        string[] lines = formattedMessage.Split('\n');

        if (lines.Length > maxLines)
        {
            formattedMessage = string.Join("\n", lines, 0, maxLines) + "\n...";
        }

        formattedMessage = $"<color={color}>{formattedMessage}</color>";

        logContent += formattedMessage + "\n";
        logText.text = logContent;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("スペースキーが押されました");
        }
    }
}
