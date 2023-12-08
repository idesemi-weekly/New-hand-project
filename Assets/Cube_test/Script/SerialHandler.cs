using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    //ポート名
    //例
    //Linuxでは/dev/ttyUSB0
    //windowsではCOM1
    //Macでは/dev/tty.usbmodem1421など
    public string portName = "COM5";
    public int baudRate    = 115200;

    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    private string message_;
    private bool isNewMessageReceived_ = false;
    public bool isDataAvailable = false;


    void Awake()
    {
        Open();
    }

    void Update()
    {
        if (isNewMessageReceived_) {
            OnDataReceived(message_);
        }
        isNewMessageReceived_ = false;
        // 新しく追加したデータの受信状態を確認する処理
        if (isDataAvailable)
        {
            Debug.Log("Data is available");
            isDataAvailable = false;
            // ここに必要な処理を追加
        }

        
    }
    void OnDestroy()
    {
        Close();
    }
    private void Open()
    {
        serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
         //または
         //serialPort_ = new SerialPort(portName, baudRate);
        serialPort_.Open();

        serialPort_.ReadTimeout = 100;
        isRunning_ = true;

        thread_ = new Thread(Read);
        thread_.Start();
    }

    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive) {
            thread_.Join();
        }

        if (serialPort_ != null && serialPort_.IsOpen) {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    private void Read()
    {
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen) {
            try {
                message_ = serialPort_.ReadLine();
                isNewMessageReceived_ = true;
                isDataAvailable = true;
            } catch (System.Exception e) {
                Debug.LogWarning(e.Message);
            }
        }
    }

    public void Write(string message)
    {
        try {
            serialPort_.WriteLine(message);
        } catch (System.Exception e) {
            Debug.LogWarning(e.Message);
        }
    }
}
