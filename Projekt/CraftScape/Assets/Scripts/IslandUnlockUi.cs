using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class UnlockUi : MonoBehaviour
{
    public IslandLock[] islands;
    private bool visible;
    public CameraManager1 cameraFollowCursor;
    void Start()
    {
        // Disable all islands initially
        foreach (IslandLock island in islands)
        {
            island.Show(false);
        }
    }
    public void VisibleAll()
    {
        cameraFollowCursor.isFollowingCursor = true;
        foreach (IslandLock island in islands)
        {
            island.Show(true);
            visible = true;
        }
    }   
    private void Update()
    {
        if (visible && Input.GetKeyDown(KeyCode.Escape)) 
        {
            HideAll();
        }
    }
    public void HideAll()
    {
        cameraFollowCursor.isFollowingCursor = false;
        foreach (var island in islands)
        {
            island.Show(false);
            visible = false;
        }
    }





}