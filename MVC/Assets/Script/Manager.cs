using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Manager : MonoBehaviour
{
    protected int _managerID = 0;
    public int managerID
    {
        get
        {
            return _managerID;
        }
    }
 
    public abstract void ReceiveMessage(Packet pk);
    public abstract void GetObject(PacketList packet, ref object obj);
}
