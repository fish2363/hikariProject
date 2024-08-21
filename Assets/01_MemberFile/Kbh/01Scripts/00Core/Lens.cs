using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lens : MonoBehaviour
{
   protected abstract LensType LensType { get; }
   public abstract void UpdateDataLink();
}
