using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Net.Sockets;
using UnityEngine.UI;
using UnityEditor;

[RequireComponent(typeof(ArduinoController))]
public class Telefone : MonoBehaviour
{

    [ReadOnly]
    public bool receiverUp = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        ButtonUpdate();
    }


    [BoxGroup("Simulador", centerLabel: true)]
    [ButtonGroup("Simulador/0"), Button("ReceiverUp"), GUIColor("GetColor0")]
    void _ReceiverUp()
    {
        if(EditorApplication.isPlaying)
            receiverUp = true;
        
        SendMessage("ReceiverDown");
        
    }
    
    [ButtonGroup("Simulador/0"), Button("ReceiverDown"), GUIColor("GetColor1")]
    void _ReceiverDown()
    {
        if(EditorApplication.isPlaying)
            receiverUp = false;
        
        SendMessage("ReceiverUp");
        
    }
    
    [ButtonGroup("Simulador/1"), Button("1"), GUIColor("GetColor2")]
    void _Key1()
    {
        SendMessage("Key1");
    }

    [ButtonGroup("Simulador/1"), Button("2"), GUIColor("GetColor3")]
    void _Key2()
    {
        SendMessage("Key2");
    }

    [ButtonGroup("Simulador/1"), Button("3"), GUIColor("GetColor4")]
    void _Key3()
    {
        SendMessage("Key3");
    }

    [ButtonGroup("Simulador/2"), Button("4"), GUIColor("GetColor5")]
    void _Key4()
    {
        SendMessage("Key4");
    }

    [ButtonGroup("Simulador/2"), Button("5"), GUIColor("GetColor6")]
    void _Key5()
    {
        SendMessage("Key5");
    }

    [ButtonGroup("Simulador/2"), Button("6"), GUIColor("GetColor7")]
    void _Key6()
    {
        SendMessage("Key6");
    }

    [ButtonGroup("Simulador/3"), Button("7"), GUIColor("GetColor8")]
    void _Key7()
    {
        SendMessage("Key7");
    }

    [ButtonGroup("Simulador/3"), Button("8"), GUIColor("GetColor9")]
    void _Key8()
    {
        SendMessage("Key8");
    }

    [ButtonGroup("Simulador/3"), Button("9"), GUIColor("GetColor10")]
    void _Key9()
    {
        SendMessage("Key9");
    }

    [ButtonGroup("Simulador/4"), Button("*"), GUIColor("GetColor11")]
    void _KeyAsterisk()
    {
        SendMessage("KeyAsterisk");
    }

    [ButtonGroup("Simulador/4"), Button("0"), GUIColor("GetColor12")]
    void _Key0()
    {
        SendMessage("Key0");
    }

    [ButtonGroup("Simulador/4"), Button("#"), GUIColor("GetColor13")]
    void _KeyHash()
    {
        SendMessage("KeyHash");
    }



    private float[] buttonTimers = new float[14];
    private static bool[] buttonPresses = new bool[14];


    void OnMessageArrived(string msg)
    {
        switch(msg.ToCharArray()[0])
        {
            case 'u':
                _ReceiverUp();
                buttonPresses[0] = true;
                buttonTimers[0] = .1f;
                break;

            case 'd':
                _ReceiverDown();
                buttonPresses[1] = true;
                buttonTimers[1] = .1f;
                break;

            case '1':
                _Key1();
                buttonPresses[2] = true;
                buttonTimers[2] = .1f;
                break;

            case '2':
                _Key2();
                buttonPresses[3] = true;
                buttonTimers[3] = .1f;
                break;

            case '3':
                _Key3();
                buttonPresses[4] = true;
                buttonTimers[4] = .1f;
                break;

            case '4':
                _Key4();
                buttonPresses[5] = true;
                buttonTimers[5] = .1f;
                break;

            case '5':
                _Key5();
                buttonPresses[6] = true;
                buttonTimers[6] = .1f;
                break;

            case '6':
                _Key6();
                buttonPresses[7] = true;
                buttonTimers[7] = .1f;
                break;

            case '7':
                _Key7();
                buttonPresses[8] = true;
                buttonTimers[8] = .1f;
                break;

            case '8':
                _Key8();
                buttonPresses[9] = true;
                buttonTimers[9] = .1f;
                break;

            case '9':
                _Key9();
                buttonPresses[10] = true;
                buttonTimers[10] = .1f;
                break;

            case '*':
                _KeyAsterisk();
                buttonPresses[11] = true;
                buttonTimers[11] = .1f;
                break;

            case '0':
                _Key0();
                buttonPresses[12] = true;
                buttonTimers[12] = .1f;
                break;

            case '#':
                _KeyHash();
                buttonPresses[13] = true;
                buttonTimers[13] = .1f;
                break;
        }
    }

    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        //else
            //Debug.Log("Connection attempt failed or disconnection detected");
    }

    void ButtonUpdate()
    {
        for(int i = 0; i < 14; i++)
        {
            if(buttonTimers[i] > 0)
            {
                buttonTimers[i] = buttonTimers[i] - Time.deltaTime;
                if(buttonTimers[i] <= 0)
                {
                    buttonTimers[i] = 0;
                    buttonPresses[i] = false;
                }

                Sirenix.Utilities.Editor.GUIHelper.RequestRepaint();
            }
        }
    }


    private static Color GetColor0(){return buttonPresses[0] ? Color.green : Color.white;}
    private static Color GetColor1(){return buttonPresses[1] ? Color.green : Color.white;}
    private static Color GetColor2(){return buttonPresses[2] ? Color.green : Color.white;}
    private static Color GetColor3(){return buttonPresses[3] ? Color.green : Color.white;}
    private static Color GetColor4(){return buttonPresses[4] ? Color.green : Color.white;}
    private static Color GetColor5(){return buttonPresses[5] ? Color.green : Color.white;}
    private static Color GetColor6(){return buttonPresses[6] ? Color.green : Color.white;}
    private static Color GetColor7(){return buttonPresses[7] ? Color.green : Color.white;}
    private static Color GetColor8(){return buttonPresses[8] ? Color.green : Color.white;}
    private static Color GetColor9(){return buttonPresses[9] ? Color.green : Color.white;}
    private static Color GetColor10(){return buttonPresses[10] ? Color.green : Color.white;}
    private static Color GetColor11(){return buttonPresses[11] ? Color.green : Color.white;}
    private static Color GetColor12(){return buttonPresses[12]? Color.green : Color.white;}
    private static Color GetColor13(){return buttonPresses[13] ? Color.green : Color.white;}
}
