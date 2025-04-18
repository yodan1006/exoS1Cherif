using UnityEngine;

namespace CourbeProgression.Runtime
{
    public class Stats : MonoBehaviour
    {
        public Stat[] stats;
    }
    
    [System.Serializable]
    public class Stat
    {
        public string m_name;
        public AnimationCurve m_curve;
        public float m_minValue;
        public float m_maxValue;


        public float GetValueAtLevel(float Level)
        {
            float normalized = Mathf.InverseLerp(m_minValue, m_maxValue, Level);
            float t = Mathf.Clamp01(normalized);
            float curvevalue = m_curve.Evaluate(t);
            
            return curvevalue;
        }
    }
}
