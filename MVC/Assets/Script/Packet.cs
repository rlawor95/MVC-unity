using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PacketList
{
    PACKET_KEYDOWN = 0, // iMessage : KeyCode
    PACKET_KEYUP = 1,    // iMessage : KeyCode
    PACKET_GETPLAYER = 2
}
public class Packet 
{
    public int senderID = 0;
    public int receiveID = 0;
    public PacketList packetID;
    public int iMessage = 0; // 무슨 키를 눌렀는가
    public object objMessage1 = null;
    public object objMessage2 = null;
    public float dispatchTime = 0; // 딜레이 타임
}
