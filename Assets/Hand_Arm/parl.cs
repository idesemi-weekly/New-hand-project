using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Leap;
using Leap.Unity;

public class parl : MonoBehaviour
{
    //SerialHandler.cのクラス
    public SerialHandler serialHandler;

    int q = 45;
    int w = 93;
    int e = 90;
    int r = 90;
    int t = 65;

    public VisibleBallHand handScript;




    void three_function(string a, int b, int c)
    {
        string p1;
        p1 = "{'start':" + $"[{a},{b},{c}]" + "}\n";
        print(p1);
        byte[] p1EncodedBytes = Encoding.GetEncoding("gbk").GetBytes(p1);
        string p1EncodedString = Encoding.GetEncoding("gbk").GetString(p1EncodedBytes);
        serialHandler.Write(p1EncodedString);
        Debug.Log(p1EncodedString);
        //ser.write("{'start':['pinmode',13,0]}\n".encode("gbk"))
    }
    void resetposition()
    {
        three_function("'servo_attach'", 0, 9);
        three_function("'servo_attach'", 1, 6);
        three_function("'servo_attach'", 2, 5);
        three_function("'servo_attach'", 3, 3);
        three_function("'servo_attach'", 4, 11);

        three_function("'servo_write'", 0, q);
        three_function("'servo_write'", 1, w);
        three_function("'servo_write'", 2, e);
        three_function("'servo_write'", 3, r);
        three_function("'servo_write'", 4, t);
    }
    void Start()
    {
        Invoke("resetposition", 3.0f);


    }

    void FixedUpdate() //ここは0.001秒ごとに実行される
    {

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(handScript.distance);
        }
        if (handScript.distance >= 1)
        {
            t = t - 1;
            if (t >= 45)
            {
                three_function("'servo_write'", 4, t);
            }
            else
            {
                t = 45;
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            w = w + 1;
            if (w <= 180)
            {
                three_function("'servo_write'", 1, w);
            }
            else
            {
                w = 180;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            w = w - 1;
            if (w >= 0)
            {
                three_function("'servo_write'", 1, w);
            }
            else
            {
                w = 0;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            q = q + 1;
            if (q <= 180)
            {
                three_function("'servo_write'", 0, q);
            }
            else
            {
                q = 180;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            q = q - 1;
            if (q <= 180)
            {
                three_function("'servo_write'", 0, q);
            }
            else
            {
                q = 0;
            }
        }
    }
}