using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakPeluruScript : MonoBehaviour
{
    private Transform myTransform;
    private float waktuTerbangPeluru;
    private TankBehaviorScript tankBehavior;
    private float _kecAwal;
    private float _sudutTembak;

    // Start is called before the first frame update
    void Start()
    {
       myTransform = transform; 
       tankBehavior = GameObject.FindObjectOfType<TankBehaviorScript>();
       _kecAwal = tankBehavior.kecepatanAwalPeluru;
       _sudutTembak = tankBehavior.nilaiRotasiY;
    }

    // Update is called once per frame
    void Update()
    {
       //timer
       waktuTerbangPeluru += Time.deltaTime; 
       myTransform.position = PosisiTerbangPeluru(myTransform.position);
    }

    private Vector3 PosisiTerbangPeluru(Vector3 _posisiSaatIni,float _kecAwal, float _sudut , float _waktu)
    {
        float _x = _posisiSaatIni.x;
        float _y = _posisiSaatIni.y;
        float _z = _posisiSaatIni.z;

        return new Vector3(_x, _y, _z);
    }
}
