using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GetWithPath<T> : Get<T>
   where T : class, IData
{
   protected override T Find()
   {
      Transform targetTrm = null;
      if(_path == "\\Parent")
      {
         T result = null;
         Transform root = _trm.root;
         targetTrm = _trm;
         
         while(result is null && targetTrm != root && targetTrm != null)
         {
            targetTrm = targetTrm.parent;
            if(targetTrm is not null)
               result = targetTrm.GetComponent<T>();
         }

         return result;
      }
      else if(_path == "")
      {
         targetTrm = _trm;
      }
      else
      {
         targetTrm = _trm.Find(_path);
      }

      return targetTrm.GetComponent<T>();
   }
}
