namespace Lisit.Repositories.SqlLiteRepositories;
internal class Queries {
    internal class Pais {
        private static readonly string table = "Paises";

        public static readonly string GetAll = $"SELECT id,nombre from {table}";

        public static readonly string GetById = $"select id,nombre from {table} where id=@id ";

        public static readonly string Create = $@"
                            INSERT INTO {table} (nombre) VALUES (@nombre);
                            SELECT last_insert_rowid();";

        public static readonly string Delete = $"delete from {table} WHERE id = @id";

        public static readonly string Update = $"UPDATE {table} SET nombre = @nombre where id = @id";
    }

    internal class Region {
        private static readonly string table = "Regiones";

        public static readonly string GetAll = $"SELECT id,nombre, pais_id as paisId from {table}";


        public static readonly string GetById = $"select id,nombre, pais_id as paisId from {table} where id=@id ";

        public static readonly string Create = $@"
                            INSERT INTO {table} (nombre,pais_id) VALUES (@nombre,@paisId);
                            SELECT last_insert_rowid();";

        public static readonly string Delete = $"delete from {table} WHERE id = @id";

        public static readonly string Update = $"UPDATE {table} SET nombre = @nombre , pais_id= @pais_id where id = @id";
    }

    internal class Comuna {
        private static readonly string table = "Comunas";

        public static readonly string GetAll = $"SELECT id,nombre, region_id as regionId from {table}";


        public static readonly string GetById = $"select id,nombre,region_id as regionId from {table} where id=@id ";

        public static readonly string Create = $@"
                            INSERT INTO {table} (nombre,region_id) VALUES (@nombre,@regionId);
                            SELECT last_insert_rowid();";

        public static readonly string Delete = $"delete from {table} WHERE id = @id";

        public static readonly string Update = $"UPDATE {table} SET nombre = @nombre , region_id= @regionId where id = @id";
    }

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
