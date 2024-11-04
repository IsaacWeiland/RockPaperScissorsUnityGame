using System.Collections.Generic;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu()]
    public class IconListSO : ScriptableObject
    {
        public List<IconSO> IconSOList;
    }
}
