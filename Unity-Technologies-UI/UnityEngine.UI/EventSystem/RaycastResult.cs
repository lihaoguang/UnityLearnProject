namespace UnityEngine.EventSystems
{
    public struct RaycastResult
    {
        private GameObject m_GameObject; // Game object hit by the raycast

        public GameObject gameObject//射线击中的物体
        {
            get { return m_GameObject; }
            set { m_GameObject = value; }
        }

        public BaseRaycaster module; // Event system that hit this object //命中此对象的事件系统
        public float distance; // The distance from the origin this hit was. //发射命中之间的距离
        public float index; // The index this element is in the raycastList (used for sorting)//层级排序
        public int depth;
        public int sortingLayer;
        public int sortingOrder;
        // World-space position where a ray cast into the screen hits something
        public Vector3 worldPosition;
        // World-space normal where a ray cast into the screen hits something
        public Vector3 worldNormal;

        public Vector2 screenPosition;

        public bool isValid
        {
            get { return module != null && gameObject != null; }
        }

        public void Clear()
        {
            gameObject = null;
            module = null;
            distance = 0;
            index = 0;
            depth = 0;
            sortingLayer = 0;
            sortingOrder = 0;
            worldNormal = Vector3.up;
            worldPosition = Vector3.zero;
            screenPosition = Vector2.zero;
        }

        public override string ToString()
        {
            if (!isValid)
                return "";

            return "Name: " + gameObject + "\n" +
                   "module: " + module + "\n" +
                   "module camera: " + module.GetComponent<Camera>() + "\n" +
                   "distance: " + distance + "\n" +
                   "index: " + index + "\n" +
                   "depth: " + depth + "\n" +
                   "worldNormal: " + worldNormal + "\n" +
                   "worldPosition: " + worldPosition + "\n" +
                   "screenPosition: " + screenPosition + "\n" +
                   "module.sortOrderPriority: " + module.sortOrderPriority + "\n" +
                   "module.renderOrderPriority: " + module.renderOrderPriority + "\n" +
                   "sortingLayer: " + sortingLayer + "\n" +
                   "sortingOrder: " + sortingOrder;
        }
    }
}
