using UnityEngine;
using UnityEngine.Events;

public class HelloCherif : MonoBehaviour
{
    #region Publics
    
    public int m_lifePoints = 100;
    public bool m_isAlive = true;
    
    public UnityEvent OnNPCDeath;

    public enum NPCState
    {
        INVALID = -1,
        IDLE,
        INTRIGUED,
        COMBAT,
        SEARCH,
    }
    
    //prioriser les data en struct
    public struct LocalisationLine
    {
        public string m_localisationId;
        public string m_characterName;
        public Color m_characterColor;
        public string m_currentLanguage;
    }
    
    public LocalisationLine m_ocalisationLine;

    public NPCState m_npcState = NPCState.IDLE;
    
    public string m_playerName = "Player";
    public char m_initial = 'P';
    
    
    public int[] m_coordination = new int[4];
    
    #endregion

    
    #region Unity API
    
    private void Start()
    {
        float myValue = 0.1f;

        switch (m_npcState)
        {
            case NPCState.IDLE:
                break;
            case NPCState.INTRIGUED:
                break;
            case NPCState.COMBAT:
                break;
            case NPCState.SEARCH:
                break;
            default:
                break;
        }
        
        if (Mathf.Approximately(myValue, 0.1f))
        {
            
        }

        var result = Mathf.Approximately(myValue, 0.1f) ? "Arrivé" : "Pas arrivé";
    }

    private void Update()
    {
        for (int i = 0; i < 50; i++)
        {
            if (!m_isAlive) continue;
            
            //choppe player
        }

        int j = 0;
        int maxInteration = 100;
        
        while (j < 50)
        {
            j++;
            if (j > maxInteration) break;
        }

        foreach (var item in m_coordination)
        {
            
        }

        int k = 0;
        
        do
        {
            k++;
        } while (k < m_coordination.Length);
    }

    #endregion
    
    
    #region Main Methods
    
    #endregion
    
    
    #region Utils
    
    #endregion
    
    
    #region Privates and protected
    
    private float _playerSpeed;
    
    #endregion
}
