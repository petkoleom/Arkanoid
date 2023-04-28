using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace darkvoyagestudios
{
    public class scr_AudioManager : StaticInstance<scr_AudioManager>
    {
        AudioSource source;

        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip clip)
        {
            print(clip.name);
            source.PlayOneShot(clip);
        }
    }
}
