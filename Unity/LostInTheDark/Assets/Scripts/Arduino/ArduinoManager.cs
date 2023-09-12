using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class ArduinoManager : MonoBehaviour
{
    [SerializeField]
    private string PortName = "COM7";
    [SerializeField]
    private int BaudRate = 9600;

    private string incomingMsg = "";
    private string outgoingMsg = "";
    private SerialPort sp;
    private Thread IOThread;

    // Start is called before the first frame update
    void Start()
    {
        IOThread = new Thread(DataThread);
        IOThread.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (incomingMsg != "")
        {
            Debug.Log(incomingMsg);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            outgoingMsg = "0";
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            outgoingMsg = "1";
    }

    private void DataThread()
    {
        sp = new SerialPort(PortName, BaudRate);

        sp.Open();

        while (true)
        {
            if (outgoingMsg != "")
            {
                sp.Write(outgoingMsg);
                outgoingMsg = "";
            }

            incomingMsg = sp.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }

}
