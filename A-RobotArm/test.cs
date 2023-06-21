using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Adeept;
using System.Threading;

int q = 45;
int w = 93;
int e = 90;
int r = 90;
int t = 65;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Adeept.com_init("COM5",115200,1);
        Adeept.wiat_connect();

        Adeept.three_function("servo_attach",0,9);
        Adeept.three_function("servo_attach",1,6);
        Adeept.three_function("servo_attach",2,5);
        Adeept.three_function("servo_attach",3,3);
        Adeept.three_function("servo_attach",4,11);

        Adeept.three_function("servo_write",0,q);
        Adeept.three_function("servo_write",1,w);
        Adeept.three_function("servo_write",2,e);
        Adeept.three_function("servo_write",3,r);
        Adeept.three_function("servo_write",4,t);
    }

    // Update is called once per frame
    void Update()
    {
        num = 0;
        if (Input.GetKey(KeyCode.A))
        {
            q = q + 0.25;
            if (q <= 180){
                Adeept.three_function("servo_write",0,q);
            }
            else{
                q = 180;
            }
        }
        if (Input.GetKey(KeyCode.W)){
            w = w + 0.25;
            if (w <= 180){
                Adeept.three_function("servo_write",1,w);
            }
            else{
                w = 180;
            }
        }
        if (Input.GetKey(KeyCode.K)){
            e = e + 0.25;
            if (e <= 180){
                Adeept.three_function("servo_write",2,e);
            }
            else{
                e = 180;
            }
        }
        if (Input.GetKey(KeyCode.Q)){
            r = r + 0.25;
            if (r <= 180){
                Adeept.three_function("servo_write",3,r);
            }
            else{
                r = 180;
            }
        }
        if (Input.GetKey(KeyCode.J)){
            t = t + 0.25;
            if (t <= 135){
                Adeept.three_function("servo_write",4,t);
            }
            else{
                t = 135;
            }
        }
        if (Input.GetKey(KeyCode.D)){
            q = q - 0.25;
            if (q >= 0){
                Adeept.three_function("servo_write",0,q);
            }
            else{
                q = 0;
            }
        }
        if (Input.GetKey(KeyCode.S)){
            w = w - 0.25;
            if (w >= 0){
                Adeept.three_function("servo_write",1,w);
            }
            else{
                w = 0;
            }
        }
        if (Input.GetKey(KeyCode.I)){
            e = e - 0.25;
            if (e >= 0){
                Adeept.three_function("servo_write",2,e);
            }
            else{
                e = 0;
            }
        }
        if (Input.GetKey(KeyCode.E)){
            r = r - 0.25;
            if (r >= 0){
                Adeept.three_function("servo_write",3,r);
            }
            else{
                r = 0;
            }
        }
        if (Input.GetKey(KeyCode.L)){
            t = t - 0.25;
            if (t >= 45){
                Adeept.three_function("servo_write",4,t);
            }
            else{
                t = 45;
            }
        }

        if (Input.GetKey(KeyCode.o)){
            Application.Quit();
        }
    }
}
