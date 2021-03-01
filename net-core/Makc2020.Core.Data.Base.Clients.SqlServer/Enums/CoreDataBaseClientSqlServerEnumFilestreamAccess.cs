//Author Maxim Kuzmin//makc//

namespace Makc2020.Core.Data.Base.Clients.SqlServer.Enums
{
    /// <summary>
    /// Ядро. Данные. Основа. Клиенты. SQL Server. Перечисления. Уровни доступа к файловому потоку.
    /// </summary>
    public enum CoreDataBaseClientSqlServerEnumFilestreamAccess : uint
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
