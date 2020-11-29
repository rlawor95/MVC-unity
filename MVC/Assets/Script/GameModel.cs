using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    public const int _PlayerMan     = 0x00000001;
    public const int _KeyMan        = 0x00000010;
    public const int _AllMan        = 0x11111111;
 
    [System.Serializable]
    public class ManagerID
    {
        public string managerName = "";
        public GameObject managerObject = null;
    }
 
    [Header("Managers")]
    public ManagerID[] managers;
    private List<Manager> managerList = new List<Manager>();
    
    private List<Packet> packets = new List<Packet>();
    private List<Packet> delayPackets = new List<Packet>();
    
    void Start()
    {
        for (int i = 0; i < managers.Length; i++)
        {
            managerList.Add(managers[i].managerObject.GetComponent<Manager>());
        }
    }
 
    private void LateUpdate()
    {
        delayPackets.Clear();
        foreach (Packet pk in packets)
        {
            if(pk.dispatchTime <= Time.time)
            {
                DispatchMessage(pk);
            }
            else
            {
                delayPackets.Add(pk);
            }
        }
        packets.Clear();
        foreach(Packet pk in delayPackets)
        {
            packets.Add(pk);
        }
    }
 
    public void sendMessage(int senderID, int receiveID, PacketList packet, int iPacket, object objPacket1, object objPacket2)
    {
        Packet pk = new Packet();
        pk.senderID = senderID;
        pk.receiveID = receiveID;
        pk.packetID = packet;
        pk.iMessage = iPacket;
        pk.objMessage1 = objPacket1;
        pk.objMessage2 = objPacket2;
        sendMessage(pk);
    }
 
    public void sendMessage(Packet packet)
    {
        DispatchMessage(packet);
    }
 
    private void DispatchMessage(Packet pk)
    {
        // ex) 0x0001 -> KeyMan
        // 0x0010 -> PlayerMan
        // 0x0100 -> SoundMan
        // 0x1000 -> UIMan
 
        // 예를들어 player, sound, ui에 메세지를 다 보내고싶다면 receiveID를 0x1110으로 보낼것임.
        // receiveID = PlayerMan | SoundMan | UIMan (or연산) = 0x1110
 
        // 그러면 매니저 foreach돌면서 &(and)연산하면서 걸리면(받는다면) 그 매니저에 메세지를 보냄
        // ex) 0x0010 & 0x1110 = 0x0010 -> PlayerMan은 메세지를 받는구나 이런식
 
        foreach(Manager mn in managerList)
        {
            int bReceive = mn.managerID & pk.receiveID;
            if (bReceive != 0)
            {
                mn.ReceiveMessage(pk);
            }
        }
    }
 
    public void postMessage(int senderID, int receiveID, PacketList packet, int iPacket, object objPacket1, object objPacket2)
    {
        Packet pk = new Packet();
        pk.senderID = senderID;
        pk.receiveID = receiveID;
        pk.packetID = packet;
        pk.iMessage = iPacket;
        pk.objMessage1 = objPacket1;
        pk.objMessage2 = objPacket2;
        packets.Add(pk);
    }
 
    public void postMessage(Packet packet)
    {
        packets.Add(packet);
    }
 
    public void delayMessage(int senderID, int receiveID, PacketList packet, int iPacket, object objPacket1, object objPacket2, float lateTime)
    {
        Packet pk = new Packet();
        pk.senderID = senderID;
        pk.receiveID = receiveID;
        pk.packetID = packet;
        pk.iMessage = iPacket;
        pk.objMessage1 = objPacket1;
        pk.objMessage2 = objPacket2;
        pk.dispatchTime = Time.time + lateTime;
        packets.Add(pk);
    }
 
    public void delayMessage(Packet packet, float lateTime)
    {
        packets.Add(packet);
    }
 
    public void GetObject(int senderID, int recieveID, PacketList packet, ref object obj)
    {
        foreach (Manager mn in managerList)
        {
            int bRecive = mn.managerID & recieveID;
            if (bRecive != 0)
            {
                mn.GetObject(packet, ref obj);
            }
        }
    }
}
