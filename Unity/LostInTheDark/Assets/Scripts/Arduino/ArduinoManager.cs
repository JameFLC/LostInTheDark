using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class ArduinoManager : MonoBehaviour
{
    [SerializeField]
    private string PortName = "COM6";

    [SerializeField]
    private int BaudRate = 9600;

    [SerializeField] AK.Wwise.Event _lfoSound = null;

    Thread IOThread;
    private SerialPort sp;
    private string incomingMsg = "";
    private string outgoingMsg = "";


    private bool isOn = false;
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

        if ((incomingMsg != "") != isOn)
        {
            isOn = incomingMsg != "";
            AudioSwitch(isOn);
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

<<<<<<< HEAD
=======
    public void AudioSwitch(bool play)
    {
        if (play)
        {
            _lfoSound.Post(gameObject);
            AkSoundEngine.PostEvent("Play_Test_Sine",this.gameObject);
        }
        else
        {
            AkSoundEngine.StopAll(this.gameObject);
        }
    }


>>>>>>> 63716dbb914713cf2b5bf62d64810ea3fbf4fdce
    // Close the thread and the Serial Port connection
    private void OnDestroy()
    {
        IOThread.Abort();
        sp.Close();
    }
}
