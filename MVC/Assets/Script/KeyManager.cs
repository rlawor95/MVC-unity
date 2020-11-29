using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : Manager
{
    public override void GetObject(PacketList packet, ref object obj)
    {
        throw new System.NotImplementedException();
    }
    public override void ReceiveMessage(Packet pk)
    {
        throw new System.NotImplementedException();
    }
 
    void Start () {
        _managerID = GameModel._KeyMan;
    }
    void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.sendMessage(GameModel._KeyMan, GameModel._PlayerMan, PacketList.PACKET_KEYDOWN, (int)KeyCode.Space, null, null);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.sendMessage(GameModel._KeyMan, GameModel._PlayerMan, PacketList.PACKET_KEYUP, (int)KeyCode.Space, null, null);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            object player = null;
            GameManager.Instance.GetObject(GameModel._KeyMan, GameModel._PlayerMan,
                PacketList.PACKET_GETPLAYER, ref player);
            GameObject p = player as GameObject;
            p.transform.position = Vector3.zero;
        }
    }
}
