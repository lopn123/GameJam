﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChanegeScene : MonoBehaviour
{
    public void StartScene()
    {
        SceneManager.LoadScene("stage01");
    }
}
