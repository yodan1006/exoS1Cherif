using System;
using UnityEngine;

namespace MapManage.Runtime
{
    public class CelluleInteractif : MonoBehaviour
    {
        #region publics

        public int m_index;

        #endregion


        #region Unity API



        #endregion


        #region Main Method

        public void Init(MapManager manager, int i)
        {
            _mapManager = manager;
            m_index = i;
        }

        #endregion


        #region Private

        private void OnMouseDown()
        {
            _mapManager.ToggleCell(m_index);
        }

        private MapManager _mapManager;

        #endregion
    }
}
