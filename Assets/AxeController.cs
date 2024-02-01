using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    public void setAxeTrue()
    {
        Hatchet.instance.setAxeTrue();
    }
    public void setAxeFalse()
    {
        Hatchet.instance.setAxeFalse();
    }
}
