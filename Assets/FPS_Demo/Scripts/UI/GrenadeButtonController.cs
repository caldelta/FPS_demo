using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GrenadeButtonController : BaseButtonController
{
    private static GrenadeButtonController m_instance;

    public static GrenadeButtonController Instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = (GrenadeButtonController)FindObjectOfType(typeof(GrenadeButtonController));

                if (m_instance == null)
                {
                    GameObject singleton = new GameObject();
                    m_instance = singleton.AddComponent<GrenadeButtonController>();
                }
            }

            return m_instance;
        }
    }
}
