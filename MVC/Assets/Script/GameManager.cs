using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GameManager();
 
            return _instance;
        }
    }
 
    public GameModel _gameModel = null;
    private GameManager()
    {
        //UnityException: FindGameObjectWithTag is not allowed to be called from a MonoBehaviour
        //constructor (or instance field initializer),
        //call it in Awake or Start instead. Called from MonoBehaviour 'GameManager'.
        
        // var gmModel = GameObject.FindGameObjectWithTag("GameModel");
        // if (gmModel)
        //     _gameModel = gmModel.GetComponent<GameModel>();
    }

    private void Awake()
    {
        var gmModel = GameObject.FindGameObjectWithTag("GameModel");
        if (gmModel)
            _gameModel = gmModel.GetComponent<GameModel>();
    }

    public void sendMessage(int senderID, int receiveID, PacketList packet, int iPacket, object objPacket1, object objPacket2)
    {
        _gameModel.sendMessage(senderID, receiveID, packet, iPacket, objPacket1, objPacket2);
    }
 
    public void sendMessage(Packet packet)
    {
        _gameModel.sendMessage(packet);
    }
 
    public void postMessage(int senderID, int receiveID, PacketList packet, int iPacket, object objPacket1, object objPacket2)
    {
        _gameModel.postMessage(senderID, receiveID, packet, iPacket, objPacket1, objPacket2);
    }
 
    public void postMessage(Packet packet)
    {
        _gameModel.postMessage(packet);
    }
 
    public void delayMessage(int senderID, int receiveID, PacketList packet, int iPacket, object objPacket1, object objPacket2, float delayTime)
    {
        _gameModel.delayMessage(senderID, receiveID, packet, iPacket, objPacket1, objPacket2, delayTime);
    }
 
    public void delayMessage(Packet packet, float delayTime)
    {
        _gameModel.delayMessage(packet, delayTime);
    }
 
    public void GetObject(int senderID, int recieveID, PacketList packet, ref object obj)
    {
        Debug.Log(senderID + " " + recieveID + " " + packet + " " + obj);
        _gameModel.GetObject(senderID, recieveID, packet, ref obj);
    }
}
