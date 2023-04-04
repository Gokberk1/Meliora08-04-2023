using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meliora08_04_2023.Abstract.Utilities;

namespace Meliora08_04_2023.Managers
{
    public class GameManager : SingletonThisObject<GameManager>
    {
        private void Awake()
        {
            SingletonThisGameObject(this);
        }
    }
}

