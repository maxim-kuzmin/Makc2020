//Author Maxim Kuzmin//makc//

using Makc2020.Core.Base.Execution;
using Makc2020.Host.Base.Parts.Auth;

namespace Makc2020.Mods.Auth.Base.Jobs.Register
{
    /// <summary>
    /// Мод "Auth". Основа. Задания. Регистрация. Результат.
    /// </summary>
    public class ModAuthBaseJobRegisterResult : CoreBaseExecutionResultWithData
        <
            HostBasePartAuthUser
        >
    {
    }
}
