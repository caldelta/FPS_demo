using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButtonController : BaseButtonController
{
    private static FireButtonController m_instance;

    public static FireButtonController Instance
    {
        get
        {
            if(m_instance == null)
            {
                m_instance = (FireButtonController)FindObjectOfType(typeof(FireButtonController));

                if (m_instance == null)
                {
                    GameObject singleton = new GameObject();
                    m_instance = singleton.AddComponent<FireButtonController>();
                }
            }

            return m_instance;
        }
    }
}
