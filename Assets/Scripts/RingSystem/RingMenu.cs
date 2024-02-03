using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMenu : MonoBehaviour
{
    public Ring Data;
    public RingCakePiece ringCakePiecePrefab;
    public float GapWidthDegree = 1f;
    public Action<string> callback;
    protected RingCakePiece[] pieces;
    protected RingMenu Parent;
    public string path;




    void Start()
    {
        var stepLength = 360f / Data.elements.Length;
        var iconDist = Vector3.Distance(ringCakePiecePrefab.icon.transform.position, ringCakePiecePrefab.cakePiece.transform.position);

        //Position it
       pieces = new RingCakePiece[Data.elements.Length];

        for (int i = 0; i < Data.elements.Length; i++)
        {
            pieces[i] = Instantiate(ringCakePiecePrefab, transform);
            //set root element
            pieces[i].transform.localPosition = Vector3.zero;
            pieces[i].transform.localRotation = Quaternion.identity;

            //set cake piece
            pieces[i].cakePiece.fillAmount = 1f / Data.elements.Length - GapWidthDegree / 360f;
            pieces[i].cakePiece.transform.localPosition = Vector3.zero;
            pieces[i].cakePiece.transform.localRotation = Quaternion.Euler(0, 0, -stepLength / 2f + GapWidthDegree / 2f + i * stepLength);
            pieces[i].cakePiece.color = new Color(1f, 1f, 1f, 0.5f);

            //set icon
            pieces[i].icon.transform.localPosition = pieces[i].cakePiece.transform.localPosition + Quaternion.AngleAxis(i * stepLength, Vector3.forward) * Vector3.up * iconDist;
            pieces[i].icon.sprite = Data.elements[i].Icon;

        }
    }

    private void Update()
    {
        
    }

    private float NormalizeAngle(float a) => (a + 360f) % 360f;
}
