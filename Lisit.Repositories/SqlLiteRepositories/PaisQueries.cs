namespace Lisit.Repositories.SqlLiteRepositories
{
    internal class PaisQueries
    {
        private static readonly string table = "Paises";

        public static readonly string GetAll = $"SELECT id,nombre from {table}";


        public static readonly string GetById = $"select id,nombre from {table} where id=@id ";

        public static readonly string Create = $@"
                            INSERT INTO {table} (nombre) VALUES (@nombre);
                            SELECT last_insert_rowid();";

        public static readonly string Delete = $"delete from {table} WHERE id = @id";

        public static readonly string Update = $"UPDATE {table} SET nombre = @nombre where id = @id";
    }
}
