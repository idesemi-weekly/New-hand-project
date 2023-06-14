from re import S
import Adeept
import time
import keyboard

global thread_flag
thread_flag = 1

q = 45
w = 93
e = 90
r = 90
t = 65
##起動時の初期数値

Adeept.com_init('COM5',115200,1)
Adeept.wiat_connect()

############cut-off rule#################

Adeept.three_function("'servo_attach'",0,9)
Adeept.three_function("'servo_attach'",1,6)
Adeept.three_function("'servo_attach'",2,5)
Adeept.three_function("'servo_attach'",3,3)
Adeept.three_function("'servo_attach'",4,11)

Adeept.three_function("'servo_write'",0,q)
Adeept.three_function("'servo_write'",1,w)
Adeept.three_function("'servo_write'",2,e)
Adeept.three_function("'servo_write'",3,r)
Adeept.three_function("'servo_write'",4,t)
##初期位置を呼び出す

num = 0

while True:
    if keyboard.is_pressed("a"):
        q = q + 0.25
        if (q <= 180):
            Adeept.three_function("'servo_write'",0,q)
        else:
            q = 180
    if keyboard.is_pressed("w"):
        w = w + 0.25
        if (w <= 180):
            Adeept.three_function("'servo_write'",1,w)
        else:
            w = 180
    if keyboard.is_pressed("k"):
        e = e + 0.25
        if (e <= 180):
            Adeept.three_function("'servo_write'",2,e)
        else:
            e = 180
    if keyboard.is_pressed("q"):
        r = r + 0.25
        if (r <= 180):
            Adeept.three_function("'servo_write'",3,r)
        else:
            r = 180
    if keyboard.is_pressed("j"):
        t = t + 0.25
        if (t <= 135):
            Adeept.three_function("'servo_write'",4,t)
        else:
            t = 135
    
    if keyboard.is_pressed("d"):
        q = q - 0.25
        if (q >= 0):
            Adeept.three_function("'servo_write'",0,q)
        else:
            q = 0
    if keyboard.is_pressed("s"):
        w = w - 0.25
        if (w >= 0):
            Adeept.three_function("'servo_write'",1,w)
        else:
            w = 0
    if keyboard.is_pressed("i"):
        e = e - 0.25
        if (e >= 0):
            Adeept.three_function("'servo_write'",2,e)
        else:
            e = 0
    if keyboard.is_pressed("e"):
        r = r - 0.25
        if (r >= 0):
            Adeept.three_function("'servo_write'",3,r)
        else:
            r = 0
    if keyboard.is_pressed("l"):
        t = t - 0.25
        if (t >= 45):
            Adeept.three_function("'servo_write'",4,t)
        else:
            t = 45

    if keyboard.is_pressed("o"):
      break 

time.sleep(2)
Adeept.three_function("'servo_write'",0,45)
Adeept.three_function("'servo_write'",1,93)
Adeept.three_function("'servo_write'",2,91)
Adeept.three_function("'servo_write'",3,90)
Adeept.three_function("'servo_write'",4,65)
"""
Adeept.three_function("'servo_write'",1,150)
time.sleep(1)
Adeept.three_function("'servo_write'",2,0)
time.sleep(1)
Adeept.three_function("'servo_write'",4,50)
time.sleep(1)
Adeept.three_function("'servo_write'",1,10)

while thread_flag:
  num = num + 30
  Adeept.three_function("'servo_write'",0,num)
  time.sleep(0.0001)
  print(type(num))
  if(num == 180):
    break
"""