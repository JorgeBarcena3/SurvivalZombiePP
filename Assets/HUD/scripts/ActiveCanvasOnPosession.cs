﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCanvasOnPosession : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void SetCanvasActive() { gameObject.SetActive(true); }
    public void setCanvasInactive() { gameObject.SetActive(false); }
    
}
