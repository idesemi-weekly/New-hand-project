using System.IO.Ports;

public class Example
{
    private static SerialPort ser;

    public static string IntToStr(int a)
    {
        string b = a.ToString();
        b = '\'' + b + '\'';
        return b;
    }

    public static void WaitOneConnect(int a)
    {
        a = a.ToString();
        string p1 = "{'start':[" + a + "]}\n";

        while (true)
        {
            ser.Write(p1);
            string line = ser.ReadLine();
            if (line != null)
            {
                a = int.Parse(line);
                return a;
            }
        }
    }

    public static char WaitOneFunction1(int a)
    {
        a = a.ToString();
        string p1 = "{'start':[" + a + "]}\n";

        while (true)
        {
            ser.Write(p1);
            string line = ser.ReadLine();
            if (line != null)
            {
                a = int.Parse(line.Substring(0, 1));
                char b = (char)a;
                return b;
            }
        }
    }

    public static void ComInit(string a, int b, int c)
    {
        ser = new SerialPort(a, b);
        ser.Timeout = c;
        ser.WriteTimeout = 10;
        ser.Open();
    }

    public static void WaitConnect()
    {
        while (true)
        {
            ser.Write("{'start':['setup']}\n");
            string line = ser.ReadLine();
            if (line != null)
            {
                break;
            }
        }
    }

    public static void OneFunction(int a)
    {
        a = a.ToString();
        string p1 = "{'start':[" + a + "]}\n";
        ser.Write(p1);
    }

    public static void TwoFunction(int a, int b)
    {
        a = a.ToString();
        b = b.ToString();
        string p1 = "{'start':[" + a + "," + b + "]}\n";
        ser.Write(p1);
    }

    public static void LCDFunction(int a, int b)
    {
        a = a.ToString();
        string bStr = IntToStr(b);
        string p1 = "{'start':[" + a + "," + bStr + "]}\n";
        ser.Write(p1);
    }

    public static int WaitTwoFunction(int a, int b)
    {
        a = a.ToString();
        b = b.ToString();
        string p1 = "{'start':[" + a + "," + b + "]}\n";

        while (true)
        {
            ser.Write(p1);
            string line = ser.ReadLine();
            if (line != null)
            {
                int result = int.Parse(line);
                return result;
            }
        }
    }

    public static void ThreeFunction(int a, int b, int c)
    {
        a = a.ToString();
        b = b.ToString();
        c = c.ToString();
        string p1 = "{'start':[" + a + "," + b + "," + c + "]}\n";
        ser.Write(p1);
    }

    public static int WaitThreeFunction(int a, int b, int c)
    {
        a = a.ToString();
        b = b.ToString();
        c = c.ToString();
        string p1 = "{'start':[" + a + "," + b + "," + c + "]}\n";

        while (true)
        {
            ser.Write(p1);
            string line = ser.ReadLine();
            if (line != null)
            {
                int result = int.Parse(line);
                return result;
            }
        }
    }

    public static char WaitThreeFunction1(int a, int b, int c)
    {
        a = a.ToString();
        b = b.ToString();
        c = c.ToString();
        string p1 = "{'start':[" + a + "," + b + "," + c + "]}\n";

        while (true)
        {
            ser.Write(p1);
            string line = ser.ReadLine();
            if (line != null)
            {
                a = int.Parse(line.Substring(0, 1));
                char b = (char)a;
                return b;
            }
        }
    }

    public static void FourFunction(int a, int b, int c, int d)
    {
        a = a.ToString();
        b = b.ToString();
        c = c.ToString();
        d = d.ToString();
        string p1 = "{'start':[" + a + "," + b + "," + c + "," + d + "]}\n";
        ser.Write(p1);
    }

    public static void FiveFunction(int a, int b, int c, int d, int e)
    {
        a = a.ToString();
        b = b.ToString();
        c = c.ToString();
        d = d.ToString();
        e = e.ToString();
        string p1 = "{'start':[" + a + "," + b + "," + c + "," + d + "," + e + "]}\n";
        ser.Write(p1);
    }

    public static void CloseSer()
    {
        ser.Close();
    }
}
