//Author Maxim Kuzmin//makc//

using Makc2020.Mods.DummyMain.Base.Common.Jobs.Options.Get.Output;
using Makc2020.Mods.DummyMain.Base.Jobs.Item.Get;
using Makc2020.Mods.DummyMain.Base.Jobs.List.Get;

namespace Makc2020.Mods.DummyMain.Caching
{
    /// <summary>
    /// Мод "DummyMain". Кэширование. Сериализация кэшируемых моделей.
    /// </summary>
    public static class ModDummyMainCachingSerialization
    {
        #region Public methods

        /// <summary>
        /// Инициализировать.
        /// </summary>
        public static void Init()
        {
            var model = ProtoBuf.Meta.RuntimeTypeModel.Default;

            InitCommonJobOptionsGetOutputItem(model);
            InitCommonJobOptionsGetOutputList(model);

            InitJobItemGetOutput(model);
            InitJobListGetOutput(model);
        }

        #endregion Public methods

        #region Private methods

        private static void InitJobItemGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyMainBaseJobItemGetOutput obj;

            model.Add(typeof(ModDummyMainBaseJobItemGetOutput), false).Add(
                nameof(obj.ObjectDummyMain),
                nameof(obj.ObjectsDummyManyToMany),
                nameof(obj.ObjectsDummyMainDummyManyToMany),
                nameof(obj.ObjectDummyOneToMany)
                );
        }

        private static void InitJobListGetOutput(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyMainBaseJobListGetOutput obj;

            model.Add(typeof(ModDummyMainBaseJobListGetOutput), false).Add(
                nameof(obj.Items),
                nameof(obj.TotalCount)
                );
        }

        private static void InitCommonJobOptionsGetOutputItem(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyMainBaseCommonJobOptionsGetOutputItem obj;

            model.Add(typeof(ModDummyMainBaseCommonJobOptionsGetOutputItem), false).Add(
                nameof(obj.Name),
                nameof(obj.Value)
                );
        }

        private static void InitCommonJobOptionsGetOutputList(ProtoBuf.Meta.RuntimeTypeModel model)
        {
            ModDummyMainBaseCommonJobOptionsGetOutputList obj;

            model.Add(typeof(ModDummyMainBaseCommonJobOptionsGetOutputList), false).Add(
                nameof(obj.Items)
                );
        }

        #endregion Private methods
    }
}