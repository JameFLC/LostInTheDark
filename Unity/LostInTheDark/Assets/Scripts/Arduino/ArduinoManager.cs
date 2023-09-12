using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class ArduinoManager : MonoBehaviour
{
    [SerializeField]
    private string PortName = "COM6";

    [SerializeField]
    private int BaudRate = 9600;

    Thread IOThread;
    private SerialPort sp;
    private string incomingMsg = "";
    private string outgoingMsg = "";

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

    // Responsible for data streaming 
    private void DataThread()
    {
        sp = new SerialPort(PortName, BaudRate);
        sp.Open();

        while (true)
        {
            if (outgoingMsg != "")
            {
                sp.Write(outgoingMsg);
                /*Debug.Log(outgoingMsg);*/
                outgoingMsg = "";
            }

            incomingMsg = sp.ReadExisting();
            Thread.Sleep(200);
        }
    }

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

    // Close the thread and the Serial Port connection
    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }
}
