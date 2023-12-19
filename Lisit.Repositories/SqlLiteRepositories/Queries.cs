namespace Lisit.Repositories.SqlLiteRepositories;
internal class Queries {
    internal class usuarios {

        private static readonly string table = "Usuarios";

        public static readonly string GetById = $"select id,nombre,email, password,es_administrador as EsAdministrator, comuna_id as comunaId from {table} where id=@id ";

        public static readonly string GetByEmail = $"select id,nombre,email, password,es_administrador as EsAdministrator, comuna_id as comunaId from {table} where email=@email ";

        public static readonly string Create = $@"insert into {table} (nombre,email,password,es_administrador,comuna_id) values (@nombre,@email,@password,@esAdministrador,@comunaId);
                                SELECT last_insert_rowid();";
    }

    internal class AyudaSocial {

        private static readonly string table = "ayuda_social";

        public static readonly string Create = $@"insert into {table} (nombre,descripcion,comuna_id) values (@nombre,@descripcion,@comunaId);
                                SELECT last_insert_rowid();";

        public static readonly string CreateByRegion = $@"
INSERT INTO {table}(nombre,descripcion,comuna_id)
SELECT @nombre,@descripcion,id
FROM   comunas
where region_id = @regionId";
    }
}
