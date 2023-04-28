using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace darkvoyagestudios
{
    public interface int_Block
    {
        public void TakeDamage(int dmg);

        public void OnTriggerEnter2D(Collider2D other);

    }
}
