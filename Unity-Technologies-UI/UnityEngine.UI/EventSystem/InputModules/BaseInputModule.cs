using System;
using System.Collections.Generic;

namespace UnityEngine.EventSystems
{
    [RequireComponent(typeof(EventSystem))]
    public abstract class BaseInputModule : UIBehaviour
    {
        [NonSerialized]
        protected List<RaycastResult> m_RaycastResultCache = new List<RaycastResult>();

        private AxisEventData m_AxisEventData;

        private EventSystem m_EventSystem;
        private BaseEventData m_BaseEventData;

        protected EventSystem eventSystem
        {
            get { return m_EventSystem; }
        }

        #region Unity Lifetime calls

        protected override void OnEnable()
        {
            base.OnEnable();
            m_EventSystem = GetComponent<EventSystem>();
            m_EventSystem.UpdateModules();
        }

        protected override void OnDisable()
        {
            m_EventSystem.UpdateModules();
            base.OnDisable();
        }

        #endregion

        public abstract void Process();

        /// <summary>
        /// 查找第一个Raycast再看看具体有什么用
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        protected static RaycastResult FindFirstRaycast(List<RaycastResult> candidates)
        {
            for (var i = 0; i < candidates.Count; ++i)
            {
                if (candidates[i].gameObject == null)
                    continue;

                return candidates[i];
            }
            return new RaycastResult();
        }

        /// <summary>
        /// 确定移动方向
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        protected static MoveDirection DetermineMoveDirection(float x, float y)
        {
            return DetermineMoveDirection(x, y, 0.6f);
        }

        protected static MoveDirection DetermineMoveDirection(float x, float y, float deadZone)
        {
            // if vector is too small... just return 如果移动距离很短 视为 没有移动方向None
            if (new Vector2(x, y).sqrMagnitude < deadZone * deadZone)
                return MoveDirection.None;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x > 0)
                    return MoveDirection.Right;
                return MoveDirection.Left;
            }
            else
            {
                if (y > 0)
                    return MoveDirection.Up;
                return MoveDirection.Down;
            }
        }

        /// <summary>
        /// 查找两个物体公同的根物体
        /// </summary>
        /// <param name="g1"></param>
        /// <param name="g2"></param>
        /// <returns></returns>
        protected static GameObject FindCommonRoot(GameObject g1, GameObject g2)
        {
            if (g1 == null || g2 == null)
                return null;

            var t1 = g1.transform;
            while (t1 != null)
            {
                var t2 = g2.transform;
                while (t2 != null)
                {
                    if (t1 == t2)
                        return t1.gameObject;
                    t2 = t2.parent;
                }
                t1 = t1.parent;
            }
            return null;
        }
        //遍历节点，直到最后一个输入的公共根，当前输入的是foung
        // walk up the tree till a common root between the last entered and the current entered is foung
        // send exit events up to (but not inluding) the common root. Then send enter events up to
        // (but not including the common root).
        protected void HandlePointerExitAndEnter(PointerEventData currentPointerData, GameObject newEnterTarget)
        {
            // if we have no target / pointerEnter has been deleted
            // just send exit events to anything we are tracking
            // then exit //如果没有进入新的目标物体或者当前指针进入为null则执行当前pointerEventData数据中所有hovered 退出方法并清空
            if (newEnterTarget == null || currentPointerData.pointerEnter == null)//从空到空returen 从有到空return 从空到有， 从有到有不执行
            {
                for (var i = 0; i < currentPointerData.hovered.Count; ++i)
                    ExecuteEvents.Execute(currentPointerData.hovered[i], currentPointerData, ExecuteEvents.pointerExitHandler);

                currentPointerData.hovered.Clear();

                if (newEnterTarget == null)
                {
                    currentPointerData.pointerEnter = newEnterTarget;
                    return;
                }
            }

            // if we have not changed hover target 如果我们没有改变悬停目标 什么都不做
            if (currentPointerData.pointerEnter == newEnterTarget && newEnterTarget)
                return;
            //currentPointerEnter=null  newEnterTarget != null =>commonRoot = null else exist
            GameObject commonRoot = FindCommonRoot(currentPointerData.pointerEnter, newEnterTarget);

            // and we already an entered object from last time 从物体到另一个物体上
            if (currentPointerData.pointerEnter != null)
            {
                // send exit handler call to all elements in the chain
                // until we reach the new target, or null!
                Transform t = currentPointerData.pointerEnter.transform;

                while (t != null)
                {
                    // if we reach the common root break out! 如果从一个目标移动到新目标则执行原来目标的退出方法，执行同父物体下与退出物体之间，的父物体中退出方法
                    if (commonRoot != null && commonRoot.transform == t)
                        break;
                    ExecuteEvents.Execute(t.gameObject, currentPointerData, ExecuteEvents.pointerExitHandler);
                    currentPointerData.hovered.Remove(t.gameObject);
                    t = t.parent;
                }
            }

            // now issue the enter call up to but not including the common root如果从一个目标移动到新目标则enter，执行同父物体下与进入物体之间，的父物体中进入方法
            currentPointerData.pointerEnter = newEnterTarget;
            if (newEnterTarget != null)
            {
                Transform t = newEnterTarget.transform;

                while (t != null && t.gameObject != commonRoot)
                {
                    ExecuteEvents.Execute(t.gameObject, currentPointerData, ExecuteEvents.pointerEnterHandler);
                    currentPointerData.hovered.Add(t.gameObject);
                    t = t.parent;
                }
            }
        }

        protected virtual AxisEventData GetAxisEventData(float x, float y, float moveDeadZone)
        {
            if (m_AxisEventData == null)
                m_AxisEventData = new AxisEventData(eventSystem);

            m_AxisEventData.Reset();
            m_AxisEventData.moveVector = new Vector2(x, y);
            m_AxisEventData.moveDir = DetermineMoveDirection(x, y, moveDeadZone);
            return m_AxisEventData;
        }

        protected virtual BaseEventData GetBaseEventData()
        {
            if (m_BaseEventData == null)
                m_BaseEventData = new BaseEventData(eventSystem);

            m_BaseEventData.Reset();
            return m_BaseEventData;
        }

        public virtual bool IsPointerOverGameObject(int pointerId)
        {
            return false;
        }

        /// <summary>
        /// Input模块是否激活
        /// </summary>
        /// <returns></returns>
        public virtual bool ShouldActivateModule()
        {
            return enabled && gameObject.activeInHierarchy;
        }

        public virtual void DeactivateModule()
        {}

        public virtual void ActivateModule()
        {}

        public virtual void UpdateModule()
        {}

        public virtual bool IsModuleSupported()
        {
            return true;
        }
    }
}