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
    private Vector3 _posisiAwal;

    // Start is called before the first frame update
    void Start()
    {
       myTransform = transform; 
       tankBehavior = GameObject.FindObjectOfType<TankBehaviorScript>();
       _kecAwal = tankBehavior.kecepatanAwalPeluru;
       _sudutTembak = tankBehavior.nilaiRotasiY;
       _posisiAwal = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
       //timer
       waktuTerbangPeluru += Time.deltaTime; 
       myTransform.position = PosisiTerbangPeluru(_posisiAwal, _kecAwal, waktuTerbangPeluru, _sudutTembak);
    }

    private Vector3 PosisiTerbangPeluru(Vector3 _posisiAwal,float _kecAwal, float _sudut , float _waktu)
    {
        float _x = _posisiAwal.x;
        float _y = _posisiAwal.y + ((_kecAwal * _waktu * Mathf.Sin(_sudut * Mathf.PI  /180)) - (0.5f * 10 * Mathf.Pow(_waktu, 2)));
        float _z = _posisiAwal.z + (_kecAwal * _waktu * Mathf.Cos(_sudut * Mathf.PI  /180));

        return new Vector3(_x, _y, _z);
    }
}
