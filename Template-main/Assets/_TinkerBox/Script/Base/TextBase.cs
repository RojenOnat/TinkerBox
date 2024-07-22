using Febucci.UI.Examples;
using TMPro;
using UnityEngine;

namespace _TinkerBox.Script.Base
{
    
    public abstract class TextBase : MonoBehaviour
    {
        public abstract TextMeshProUGUI TMP { get; set; }

       

        public virtual void SetText(TextMeshProUGUI tmp, string value)
        {
            TMP = tmp;
            tmp.text = value;
        }

    }
}