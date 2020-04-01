//Author Maxim Kuzmin//makc//

using Makc2020.Mods.DummyTree.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyTree.Base.Jobs.List.Get;

namespace Makc2020.Mods.DummyTree.Caching
{
    /// <summary>
    /// Мод "DummyTree". Кэширование. Сериализация кэшируемых моделей.
    /// </summary>
    public static class ModDummyTreeCachingSerialization
    {
        #region Public methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        public static void Init()
        {
            var model = ProtoBuf.Meta.RuntimeTypeModel.Default;

            InitJobItemGetOutput(model);
            InitJobListGetOutput(model);
        }

        #endregion Public methods

        #region Private methods

        private static void InitJobItemGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyTreeBaseJobItemGetOutput obj;

            model.Add(typeof(ModDummyTreeBaseJobItemGetOutput), false).Add(
                nameof(obj.ObjectDummyTree)
                );
        }

        private static void InitJobListGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyTreeBaseJobListGetOutput obj;

            model.Add(typeof(ModDummyTreeBaseJobListGetOutput), false).Add(
                nameof(obj.Items),
                nameof(obj.TotalCount)
                );
        }

        #endregion Private methods
    }
}