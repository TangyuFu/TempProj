namespace UnityGameFramework.Runtime.Extension
{
    /// <summary>
    /// MVC 界面，处理界面的显示和操作逻辑，事件处理抛出给 MVC 代表者处理。
    /// </summary>
    /// <typeparam name="TProp">MVC 属性。</typeparam>
    public abstract class MVCView<TProp> where TProp : MVCProp
    {
        protected TProp m_Prop;

        public virtual void Init(TProp prop)
        {
            m_Prop = prop;
        }

        public virtual void Deinit()
        {
            m_Prop = null;
        }
    }
}