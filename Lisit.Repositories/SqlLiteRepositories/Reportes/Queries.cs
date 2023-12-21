using System.Diagnostics.CodeAnalysis;

namespace Lisit.Repositories.SqlLiteRepositories.Reportes {

    [ExcludeFromCodeCoverage]
    internal class Queries {
        internal class Reportes {

            private static readonly string table = "Usuarios";

            private static readonly string baseQuery = $@"
SELECT asa.fecha_creacion as fechaAsignacion,asa.[year] as ayudaAño,u.nombre as vecinoNombre ,u.email as vecinoEmail, a.nombre  as ayudaNombre,a.descripcion as ayudaDescripcion, c.nombre as comunaNombre
FROM ayuda_social_asignacion asa  
    INNER JOIN Usuarios u  on asa.usuario_id = u.id 
    INNER JOIN ayuda_social a on asa.ayuda_social_id =  a.id 
    INNER JOIN Comunas c on a.comuna_id = c.id 
";

            public static readonly string GetByUser = $"{baseQuery} WHERE u.id = @idUsuario";

            public static readonly string GetByUserAndYear = $"{baseQuery} WHERE u.id = @idUsuario and asa.[year] = @year";

            public static readonly string GetByYear = $"{baseQuery} WHERE  asa.[year] = @year";
        }
    }
}
