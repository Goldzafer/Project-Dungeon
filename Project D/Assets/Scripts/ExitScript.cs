﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    public RoomScript roomscript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        roomscript.exitDungeon();
    }
}
