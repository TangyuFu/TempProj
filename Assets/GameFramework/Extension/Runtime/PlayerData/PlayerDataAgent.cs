using System;

namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// 玩家数据代理泛型抽象类。
    /// </summary>
    /// <typeparam name="T">玩家数据类型。</typeparam>
    public abstract class PlayerDataAgent<T> : IPlayerDataAgent where T : PlayerData
    {
        /// <summary>
        /// 是否本地保存。
        /// </summary>
        public abstract bool Local { get; }

        /// <summary>
        /// 获取玩家数据。
        /// </summary>
        protected T Data { get; private set; }

        /// <summary>
        /// 默认的玩家数据，初始化数据时使用。
        /// </summary>
        protected abstract T DefaultData { get; }

        /// <summary>
        /// 加载数据后回调。
        /// </summary>
        public virtual bool Load()
        {
            try
            {
                Data = Local
                    ? Entry.Setting.GetObject<T>(typeof(T).FullName, DefaultData)
                    : DefaultData;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 保存数据前回调。
        /// </summary>
        public virtual bool Save()
        {
            try
            {
                if (Local)
                {
                    Entry.Setting.SetObject(typeof(T).FullName, Data);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}