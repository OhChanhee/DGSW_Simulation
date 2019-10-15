using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class StaticObject : MonoBehaviour
    {
        private static StaticObject  mInstance;
        public static StaticObject instance
        {
            get
            {
                mInstance = FindObjectOfType<StaticObject>();

                if(mInstance == null)
                {
                    mInstance = new GameObject("StaticObject").AddComponent<StaticObject>();
                }

                return mInstance;
            }
        }
    }
}
