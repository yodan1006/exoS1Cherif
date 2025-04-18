using UnityEngine;

namespace MapManage.Runtime
{
    public class GptLol : MonoBehaviour
    {
        #region Public Fields

        public GameObject m_prefabs;
        public Vector2Int m_mapDimensions;

        public sbyte[] m_levelDisign = new sbyte[]
        {
            0, 1, 0, 1, 0,
            1, 0, 1, 0, 1,
            0, 1, 0, 1, 0,
            1, 0, 1, 0, 1,
        };

        #endregion

        #region Private Fields

        [SerializeField] private Color _waterColor = Color.blue;
        [SerializeField] private Color _groundColor = Color.green;
        [SerializeField] private Color _dirtColor = Color.gray;

        private GameObject[] m_cells;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            int size = m_mapDimensions.x * m_mapDimensions.y;
            m_cells = new GameObject[size];

            for (int i = 0; i < size; i++)
            {
                Vector2Int coord = GrillageMap(i);
                GameObject cell = Instantiate(m_prefabs, new Vector3(coord.x, coord.y, 0), Quaternion.identity, transform);
                m_cells[i] = cell;
                MapDisign(i, cell);
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                NextGeneration();
            }
        }

        #endregion

        #region Core Logic

        private void NextGeneration()
        {
            int size = m_mapDimensions.x * m_mapDimensions.y;
            sbyte[] newStates = new sbyte[size];

            for (int i = 0; i < size; i++)
            {
                Vector2Int coord = GrillageMap(i);
                int aliveNeighbors = CompteALife(coord);
                int currentState = m_levelDisign[i];

                if (currentState == 1)
                    newStates[i] = (sbyte)((aliveNeighbors == 2 || aliveNeighbors == 3) ? 1 : 0);
                else
                    newStates[i] = (sbyte)((aliveNeighbors == 3) ? 1 : 0);
            }

            for (int i = 0; i < size; i++)
            {
                m_levelDisign[i] = newStates[i];
                MapDisign(i, m_cells[i]);
            }
        }

        private int CompteALife(Vector2Int coord)
        {
            int count = 0;

            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (x == 0 && y == 0) continue;

                    Vector2Int neighbor = coord + new Vector2Int(x, y);
                    if (EstDansLaGrille(neighbor))
                    {
                        int index = neighbor.y * m_mapDimensions.x + neighbor.x;
                        if (m_levelDisign[index] == 1) count++;
                    }
                }
            }

            return count;
        }

        private bool EstDansLaGrille(Vector2Int position)
        {
            return position.x >= 0 && position.x < m_mapDimensions.x &&
                   position.y >= 0 && position.y < m_mapDimensions.y;
        }

        private Vector2Int GrillageMap(int index)
        {
            return new Vector2Int(index % m_mapDimensions.x, index / m_mapDimensions.x);
        }

        private void MapDisign(int index, GameObject cell)
        {
            var state = m_levelDisign[index];
            Renderer renderer = cell.GetComponent<Renderer>();

            switch (state)
            {
                case 0:
                    renderer.material.color = _waterColor;
                    break;
                case 1:
                    renderer.material.color = _groundColor;
                    break;
                case 2:
                    renderer.material.color = _dirtColor;
                    break;
            }
        }

        #endregion
    }
}