using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager
{
    public override void ReceiveMessage(Packet pk)
    {
        switch (pk.packetID)
        {
            case PacketList.PACKET_KEYDOWN:
            {
                KeyDown(pk.iMessage);
            }
                break;
            case PacketList.PACKET_KEYUP:
            {
                KeyUp(pk.iMessage);
            }
                break;
        }
    }
 
    private void KeyDown(int keyCode)
    {
        if (keyCode == (int)KeyCode.Space)
            bSpace = true;
    }
    private void KeyUp(int keyCode)
    {
        if (keyCode == (int)KeyCode.Space)
            bSpace = false;
    }
 
    private bool bSpace = false;
    public GameObject player = null;
 
    void Start () {
        _managerID = GameModel._PlayerMan;
    }
    void Update () {
        if(bSpace)
        {
            transform.position += new Vector3(1, 0) * Time.deltaTime * 2f;
        }
    }
 
    public override void GetObject(PacketList packet, ref object obj)
    {
        if (packet == PacketList.PACKET_GETPLAYER)
        {
            obj = player;
        }
    }
}
