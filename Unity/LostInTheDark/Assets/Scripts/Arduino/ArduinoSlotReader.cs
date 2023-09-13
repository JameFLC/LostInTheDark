using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class ArduinoSlotReader : MonoBehaviour
{
    [SerializeField]
    private string PortName = "COM6";

    [SerializeField]
    private int BaudRate = 9600;

    [SerializeField]
    private UnityEvent<int> PawnSlotIndexChanged;

    Thread IOThread;
    private SerialPort serialPort;

    private int currentSlotIndex = 0;
    private bool shoudInvokeEvent = true;

    string slotMessage = "";
    // Start is called before the first frame update
    void Start()
    {
        IOThread = new Thread(ReadArduino);
        IOThread.Start();
    }

    private void ReadArduino()
    {
        serialPort = new SerialPort(PortName, BaudRate); 
        serialPort.Open();

        while (true)
        {
            slotMessage = serialPort.ReadExisting();


            if (slotMessage != null)
            {
                var reader = new StringReader(slotMessage);
                slotMessage = reader.ReadLine();
            }

            int newSlotIndex = 0;

            bool wasParsed = int.TryParse( slotMessage, out newSlotIndex );


            Debug.Log(slotMessage);

            bool hasIndexChanged = newSlotIndex != currentSlotIndex;


            if (wasParsed && hasIndexChanged)
            {
                currentSlotIndex = newSlotIndex;
                shoudInvokeEvent = true;
            }

            Thread.Sleep(200);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shoudInvokeEvent)
        {
            Debug.Log("ShouldInvokeEvent Main");
            PawnSlotIndexChanged.Invoke(currentSlotIndex);
            shoudInvokeEvent = false;
        }
    }
}
