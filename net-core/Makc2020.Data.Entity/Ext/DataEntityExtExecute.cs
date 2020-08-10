//Author Maxim Kuzmin//makc//

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Makc2020.Data.Entity.Ext
{
    /// <summary>
    /// Данные. Entity Framework. Расширение. Выполнить.
    /// </summary>
    public static class DataEntityExtExecute
    {
        #region Public methods

        /// <summary>
        /// Данные. Entity Framework. Расширение. Выполнить. SQL-скрипт из файла.
        /// </summary>
        /// <param name="migrationBuilder">Построитель миграции.</param>
        /// <param name="migrationFolderName">Имя папки миграции.</param>
        /// <param name="direction">Направление.</param>
        /// <param name="sqlFolderName">Имя папки с SQL-скриптами.</param>
        public static void DataEntityExtExecuteSqlFromFolder(
            this MigrationBuilder migrationBuilder,
            string migrationFolderName,
            string direction,
            string sqlFolderName
            )
        {
            var sqlFolderPath = Path.Combine(
                AppContext.BaseDirectory,
                "DataFiles",
                "Migrations",
                migrationFolderName,
                direction,
                sqlFolderName
            );

            if (Directory.Exists(sqlFolderPath))
            {
                foreach (var sqlFilePath in Directory.GetFiles(sqlFolderPath, "*.sql").OrderBy(x => x))
                {
                    var sql = File.ReadAllText(sqlFilePath, Encoding.UTF8);

                    migrationBuilder.Sql(sql);
                }
            }
            else
            {
                throw new DirectoryNotFoundException($"Migration SQL-folder \"{sqlFolderPath}\" not found");
            }
        }

        /// <summary>
        /// Данные. Entity Framework. Расширение. Выполнить. SQL-скрипт из файла.
        /// </summary>
        /// <param name="migrationBuilder">Построитель миграции.</param>
        /// <param name="migrationFolderName">Имя папки миграции.</param>
        /// <param name="direction">Направление.</param>
        /// <param name="sqlFileName">Имя файла с SQL-скриптом.</param>
        public static void DataEntityExtExecuteSqlFromFile(
            this MigrationBuilder migrationBuilder,
            string migrationFolderName,
            string direction,
            string sqlFileName
            )
        {
            var sqlFilePath = Path.Combine(
                AppContext.BaseDirectory,
                "DataFiles",
                "Migrations",
                migrationFolderName,
                direction,
                sqlFileName
            );

            if (File.Exists(sqlFilePath))
            {
                var sql = File.ReadAllText(sqlFilePath, Encoding.UTF8);

                migrationBuilder.Sql(sql);
            }
            else
            {
                throw new FileNotFoundException($"Migration SQL-file \"{sqlFilePath}\"not found");
            }
        }

        #endregion Public methods
    }
}
