using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehaviorScript : MonoBehaviour
{
    private Transform myTransform;
    private GameObject selongsong;
    private GameObject titikTembakan;
    private AudioSource audioSource;
    private string stateRotasiVertikal; //aman, bawah, atas
    public float sudutMeriam;
    [HideInInspector]
    public float nilaiRotasiY;
    public float kecepatanRotasi = 20;
    public float kecepatanAwalPeluru =20;
    public GameObject objekTembakan;
    public GameObject objekLedakan;
    public GameObject peluruMeriam;
    public AudioClip audioTembakan;
    public AudioClip audioLedakan;

    // Start is called before the first frame update
    void Start()
    {
       myTransform = transform; 
       
       //inisialisasi objek selongsong
       selongsong = myTransform.Find("selongsong").gameObject;

       //inisialisasi titik tembakan
       titikTembakan = selongsong.transform.Find("titiktembakan").gameObject;

       //inisialisasi komponen audio source
       audioSource = selongsong.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      #region Rotasi Horisontal
      if( Input.GetKey(KeyCode.T))    //rotasi berlawanan dengan jarum jam
         {
            myTransform.Rotate(Vector3.back * kecepatanRotasi * Time.deltaTime, Space.Self );
         }
      else if( Input.GetKey(KeyCode.U))    //rotasi horisontal searah dengan jarum jam
         {
            myTransform.Rotate(Vector3.forward * kecepatanRotasi * Time.deltaTime, Space.Self );
         }
      sudutMeriam = myTransform.localEulerAngles.z;
      #endregion
      
      #region Menentukan State
      nilaiRotasiY = 360 - selongsong.transform.localEulerAngles.x;
      if (nilaiRotasiY == 0 || nilaiRotasiY ==360)
      {
         stateRotasiVertikal = "aman";
      }
      else if (nilaiRotasiY > 0 && nilaiRotasiY < 15)
      {
         stateRotasiVertikal = "aman";
      }
      else if (nilaiRotasiY > 15 && nilaiRotasiY < 16)
      {
         stateRotasiVertikal = "atas";
      }
      else if (nilaiRotasiY > 350)
      {
         stateRotasiVertikal = "bawah";
      }
      #endregion

      #region Arah Rotasi Berdasarkan State
      if (stateRotasiVertikal == "aman")
      {
         if(Input.GetKey(KeyCode.Y))
         {
            selongsong.transform.Rotate(Vector3.left * kecepatanRotasi * Time.deltaTime, Space.Self);
         }
         else if(Input.GetKey(KeyCode.H))
         {
            selongsong.transform.Rotate(Vector3.right * kecepatanRotasi * Time.deltaTime, Space.Self);
         }
      } 
      else if (stateRotasiVertikal == "bawah")
      {
         selongsong.transform.localEulerAngles = new Vector3(
            -0.5f, selongsong.transform.localEulerAngles.y, selongsong.transform.localEulerAngles.z);
      }
      else if (stateRotasiVertikal == "atas")
      {
         selongsong.transform.localEulerAngles = new Vector3(
            -14.5f, selongsong.transform.localEulerAngles.y, selongsong.transform.localEulerAngles.z);
      }
      #endregion

      #region Penembakan
      if ( Input.GetKeyDown(KeyCode.Space))
      {
         #region Init Peluru
         GameObject peluru = Instantiate(peluruMeriam, titikTembakan.transform.position, 
            Quaternion.Euler(
               selongsong.transform.localEulerAngles.x,
               myTransform.localEulerAngles.z,
               0));    
         #endregion
         
         #region Init Objek Tembakan
         GameObject efekTembakan = Instantiate(objekTembakan, titikTembakan.transform.position, 
            Quaternion.Euler(
               selongsong.transform.localEulerAngles.x,
               myTransform.localEulerAngles.z,
               0)); 

         Destroy(efekTembakan, 1f);
         #endregion

         #region Init Audio Objek Tembakan
         audioSource.PlayOneShot(audioLedakan);    
         #endregion
      }    
      #endregion
    }
}
