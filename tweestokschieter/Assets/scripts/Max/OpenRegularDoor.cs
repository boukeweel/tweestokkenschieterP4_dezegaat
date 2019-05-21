using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class OpenRegularDoor : MonoBehaviour
{
    public GameObject Player;
    public float range;
    public LayerMask layerMask;
    public LayerMask layerMask1;
    public LayerMask layerMask2;
    public LayerMask layerMask3;
    public LayerMask layerMask4;
    public Animator[] animator;
    public int[] IsOpen;
    int current = 0;

    private void Start()
    {
        IsOpen = new int[6];
        for (int i = 0; i < IsOpen.Length; i++)
            IsOpen[i] = 0;
    }

    void Update()
    {
        if (XCI.GetButtonDown(XboxButton.Y, XboxController.First) || Input.GetKeyDown(KeyCode.F))
        {
            OpenOrClose();
        }
    }

    void OpenOrClose()
    {
        RaycastHit hit;
        for (int i = 0; i < 6; i++)
        {
            CheckDoor(out hit, i);
        }
    }

    /// <summary>
    /// raycast checked of the layermask en doet steeds 1 erbij deur staat op een toggle waardoor je hem open en dicht kan doen
    /// </summary>
    /// <param name="_hit"></param>
    /// <param name="_index"></param>
    /// <returns></returns>
    private bool CheckDoor(out RaycastHit _hit, int _index)
    {
        if (Physics.Raycast(Player.transform.position, Player.transform.forward, out _hit, range, _index == 0 ? 1 << LayerMask.NameToLayer("door") : 1 << LayerMask.NameToLayer("door" + _index)))
        {
            IsOpen[_index] = IsOpen[_index] == 1 ? 0 : 1;
            animator[_index].SetBool("active", IsOpen[_index] == 1 ? true : false);
            return true;
        }
        return false;
    }
}
