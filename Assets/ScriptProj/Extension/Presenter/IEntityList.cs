namespace TempProj
{
    /// <summary>
    /// 实体列表接口。
    /// </summary>
    public interface IEntityList
    {
        /// <summary>
        /// 实体显示时调用。
        /// </summary>
        /// <param name="entityId">实体 Id。</param>
        /// <param name="entityPresenter">实体代表者。</param>
        void OnShow(int entityId, IEntityPresenter entityPresenter);

        /// <summary>
        /// 实体隐藏时调用。
        /// </summary>
        /// <param name="entityId">实体 Id。</param>
        /// <param name="entityPresenter">实体代表者。</param>
        void OnHide(int entityId, IEntityPresenter entityPresenter);
    }
}