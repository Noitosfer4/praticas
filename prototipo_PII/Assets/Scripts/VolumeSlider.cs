using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
   [SerializeField] Slider volumeBotao;

   void Start(){
        volumeBotao.value = PlayerPrefs.GetFloat("musicVolume", 1);
        volumeBotao.onValueChanged.AddListener(delegate {MudarVolume();});
   }

   public void MudarVolume(){
    float volume = volumeBotao.value;
    AudioListener.volume = volume;
    if (Musica.instancia != null) {
        Musica.instancia.SetVolume(volume);
     }
    Save();
     }


   private void Save(){
        PlayerPrefs.SetFloat("musicVolume" , volumeBotao.value);
   }
}
