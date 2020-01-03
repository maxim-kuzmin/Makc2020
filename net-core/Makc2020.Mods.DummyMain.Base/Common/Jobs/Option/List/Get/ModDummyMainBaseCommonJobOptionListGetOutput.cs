//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Common.Jobs.Option.List.Get;
using Makc2020.Mods.DummyMain.Base.Common.Jobs.Option.Item.Get;

namespace Makc2020.Mods.DummyMain.Base.Common.Jobs.Option.List.Get
{
    /// <summary>
    /// Мод "DummyMain". Основа. Общее. Задания. Вариант выбора. Список. Получение. Вывод.
    /// </summary>
    public class ModDummyMainBaseCommonJobOptionListGetOutput : CoreBaseCommonJobOptionListGetOutput
        <
            ModDummyMainBaseCommonJobOptionItemGetOutput 
        >
    {
    }
}