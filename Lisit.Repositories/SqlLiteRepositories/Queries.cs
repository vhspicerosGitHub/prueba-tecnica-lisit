﻿using System.Diagnostics.CodeAnalysis;

namespace Lisit.Repositories.SqlLiteRepositories;

[ExcludeFromCodeCoverage]
internal class Queries {
    internal class usuarios {

        private static readonly string table = "Usuarios";

        public static readonly string GetById = $"select id,nombre,email, password,es_administrador as EsAdministrador, comuna_id as comunaId from {table} where id=@id ";

        public static readonly string GetByEmail = $"select id,nombre,email, password,es_administrador as EsAdministrador, comuna_id as comunaId from {table} where UPPER(email) = UPPER(@email) ";

        public static readonly string GetAll = $"select id,nombre,email, password,es_administrador as EsAdministrador, comuna_id as comunaId from {table}";

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

    internal class AyudaSocialAsignacion {
        private static readonly string table = "ayuda_social_asignacion";

        public static readonly string Create = $@"insert into {table} (usuario_id,ayuda_social_id,year,fecha_creacion) values (@usuarioId,@ayudaId,@year,DATETIME('now','localtime'));
                                SELECT last_insert_rowid();";

        public static readonly string ObtieneAsignacion = $@"SELECT id, usuario_id,ayuda_social_id,year,fecha_creacion 
                                                                FROM {table}
                                                                WHERE usuario_id = @usuarioId and ayuda_social_id = @ayudaId and year = @year ";
    }
    internal class LogNegocio {
        private static readonly string table = "negocio_log";

        public static readonly string Create = $@"insert into {table} (usuario_id,accion,fecha_accion) values (@usuarioId,@accion,DATETIME('now','localtime'));
                                SELECT last_insert_rowid();";

        public static readonly string GetAll = $@"select id, usuario_id as usuarioId, accion, fecha_Accion as fechaAccion from {table}";
    }
}
