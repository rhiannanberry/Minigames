﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEnteringBehaviour : EnteringBehaviour
{
    protected override void OnStateEnter() {
        MusicManager.INSTANCE.CheckTransition();
        print("CHECKING...");
    }

    protected override void OnStateExit() {
        print("CHECKING END...");
    }
}
