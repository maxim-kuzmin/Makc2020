//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Data.Clients.SqlServer.Enums
{
    /// <summary>
    /// Ядро. Данные. Клиенты. SQL Server. Перечисления. Уровни доступа к файловому потоку.
    /// </summary>
    public enum CoreDataClientSqlServerEnumFilestreamAccess : uint
    {
        /// <summary>
        /// Прочитать.
        /// </summary>
        Read,
        /// <summary>
        /// Записать.
        /// </summary>
        Write,
        /// <summary>
        /// Прочитать и записать.
        /// </summary>
        ReadWrite
    }
}
