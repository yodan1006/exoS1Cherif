using System;
using UnityEditor.Graphs;
using UnityEngine;

namespace MapManage.Runtime
{
    public class MapManager : MonoBehaviour
    {
        #region publics

        public GameObject m_prefabs;
        public Vector2Int m_mapDimensions;

        public sbyte[] m_levelDisign = new sbyte[]
        {
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
            0, 0, 0, 0, 0,
        };
        GameObject[] m_cell;

        #endregion

        #region Unity API

        private void Awake()
        {
            var size = m_mapDimensions.x * m_mapDimensions.y;
            m_cell = new GameObject[size];
            //Vector3 currentCellPosition = new Vector3();
            //var etats = new int[size];
            for (int i = 0; i < m_levelDisign.Length; i++)
            {
                Vector2Int coordonne = GrillageMap(null, i);
                GameObject cell = Instantiate(m_prefabs, new Vector3(coordonne.x, coordonne.y, 0), Quaternion.identity, transform);
                m_cell[i] = cell;
                MapDisign(i, cell);
            }

            #region useless

            // var index =IndexFrom2DCoordinate(_position,m_mapDimensions);
            // print(index);
            // var coord = Coordinate2DFromIndex(indexForCoo, m_mapDimensions);
            // print(coord);

            #endregion

        }

        private void Update()
        {
            NextGen();
        }

        void NextGen()
        {
            if (Input.GetMouseButtonDown(0))
        {
            var size = m_mapDimensions.x * m_mapDimensions.y;
            sbyte[] NewEtats = new sbyte[size];
            for (sbyte i = 0; i < size; i++)
            {
                Vector2Int coordonne = GrillageMap(m_prefabs, i);
                int OnALife = CompteALife(coordonne);
                int etatActuel = m_levelDisign[i];
                if (etatActuel == 1)
                {
                    int result = (OnALife == 2 || OnALife == 3) ? 1 : 0;
                    NewEtats[i] = (sbyte)result;
                }
                else
                {
                    int result = (OnALife == 2 || OnALife == 3) ? 1 : 0;
                    NewEtats[i] = (sbyte)result;
                }

                for (int j = 0; j < size; j++)
                {
                    m_levelDisign[j] = NewEtats[j];
                    MapDisign(j, m_cell[j]);
                }
            }
        }
        }
    

    private int CompteALife(Vector2Int coordonne)
        {
            int count = 0;
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0) continue;

                    Vector2Int neighbor = coordonne + new Vector2Int(x, y);
                    if (EstDansLaGrille(neighbor))
                    {
                        int index = neighbor.y * m_mapDimensions.x + neighbor.x;
                        if (m_levelDisign[index] == 1) count++;
                    }
                }
            }
            return count;
        }

        private bool EstDansLaGrille(Vector2Int voisin)
        {
            return voisin.x >= 0 && voisin.x < m_mapDimensions.x && 
                   voisin.y >= 0 && voisin.y < m_mapDimensions.y;
        }

        #endregion


        #region Main Methode

        

        #endregion
        
        
        #region privat

        // private void MapDisign1(int i, GameObject currentcell)
        // {
        //     var inter = m_levelDisign[i];
        //     Material renderer = currentcell.GetComponent<Renderer>().sharedMaterial;
        //     switch (inter)
        //     {
        //         case 0 : renderer.color = _waterColor; break;
        //         case 1: renderer.color = _groundColor; break;
        //         case 2: renderer.color = _dirtColor; break;
        //     }
        // }
        
        private void MapDisign(int i, GameObject currentcell)
        {
            var inter = m_levelDisign[i];
            Renderer renderer = currentcell.GetComponent<Renderer>();
            switch (inter)
            {
                case 0 : renderer.material.color = _waterColor; break;
                case 1: renderer.material.color = _groundColor; break;
                case 2: renderer.material.color = _dirtColor; break;
            }
        }
        
        private Vector2Int GrillageMap(GameObject currentcell, int i)
        {
            return new Vector2Int(i % m_mapDimensions.x, i / m_mapDimensions.x);
        }

        private int IndexFrom2DCoordinate(Vector2Int position, Vector2Int mapDimensions)
        {
            int index = mapDimensions.x * position.y + position.x + 1;
                return index;
        }

        private Vector2Int Coordinate2DFromIndex(int index, Vector2Int mapDimensions)
        {
            mapDimensions.x = index %  m_mapDimensions.x;
            mapDimensions.y = (index / m_mapDimensions.x) + 1;
            return mapDimensions;
        }
        
        [SerializeField]private int _grillageTaille;
        [SerializeField]private Vector2Int _position;
        [SerializeField] private int indexForCoo;
        [SerializeField] private Color _waterColor = Color.blue;
        [SerializeField] private Color _groundColor = Color.green;
        [SerializeField] private Color _dirtColor = Color.gray;
        

        #endregion
    }
}
