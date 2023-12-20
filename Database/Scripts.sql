-- Eliminacion
DROP TABLE IF EXISTS comunas;
DROP TABLE IF EXISTS Regiones;
DROP TABLE IF EXISTS paises;
DROP TABLE IF EXISTS usuarios;
DROP TABLE IF EXISTS ayuda_social;
DROP TABLE IF EXISTS ayuda_social_asignacion;
DROP TABLE IF EXISTS negocio_log;


-- TABLAS
CREATE TABLE IF NOT EXISTS Paises(
  id    INTEGER PRIMARY KEY AUTOINCREMENT, 
  nombre  TEXT
);

CREATE TABLE IF NOT EXISTS Regiones(
  id    INTEGER PRIMARY KEY AUTOINCREMENT, 
  nombre   TEXT, 
  pais_id INTEGER,
  FOREIGN KEY(pais_id) REFERENCES Paises(id)
);

CREATE TABLE IF NOT EXISTS  Comunas(
  id    INTEGER PRIMARY KEY AUTOINCREMENT, 
  nombre   TEXT, 
  region_id INTEGER,
  FOREIGN KEY(region_id) REFERENCES Regiones(id)
);

CREATE TABLE IF NOT EXISTS  Usuarios(
  id    INTEGER PRIMARY KEY AUTOINCREMENT, 
  nombre   TEXT, 
  email   TEXT, 
  password   TEXT, 
  es_administrador   BOOLEAN,   
  comuna_id INTEGER,
  FOREIGN KEY(comuna_id) REFERENCES Comunas(id)
);

CREATE TABLE IF NOT EXISTS  ayuda_social(
  id    INTEGER PRIMARY KEY AUTOINCREMENT, 
  nombre   TEXT, 
  descripcion   TEXT,
  comuna_id INTEGER,
  FOREIGN KEY(comuna_id) REFERENCES Comunas(id)
);

CREATE TABLE IF NOT EXISTS  ayuda_social_asignacion(
  id                INTEGER PRIMARY KEY AUTOINCREMENT, 
  ayuda_social_id   INTEGER, 
  usuario_id        INTEGER,
  [year]            INTEGER,
  fecha_creacion    INTEGER,
  FOREIGN KEY(ayuda_social_id) REFERENCES ayuda_social(id)
  FOREIGN KEY(usuario_id) REFERENCES Usuarios(id)
);

CREATE TABLE IF NOT EXISTS  negocio_log(
  id                INTEGER PRIMARY KEY AUTOINCREMENT, 
  usuario_id        INTEGER,
  accion            TEXT,
  fecha_accion    INTEGER,
  FOREIGN KEY(usuario_id) REFERENCES Usuarios(id)
);


-- INSERT
insert into paises (nombre) values('Chile');
insert into paises (nombre) values('Argentina');
insert into paises (nombre) values('Brasil');

insert into Regiones(pais_id,nombre) values (1,'Region Metropolitana');
insert into Regiones(pais_id,nombre) values (1,'I Region');
insert into Regiones(pais_id,nombre) values (1,'II Region');

insert into comunas(region_id,nombre) values (3,'Santiago Centro');
insert into comunas(region_id,nombre) values (3,'Maipu');
insert into comunas(region_id,nombre) values (3,'Providencia');
insert into comunas(region_id,nombre) values (3,'Puente Alto');


insert into usuarios (nombre,email,password,es_administrador,comuna_id) values ('Victor Hugo Saavedra','vhspiceros@gmail.com','123',1,1);
insert into usuarios (nombre,email,password,es_administrador,comuna_id) values ('Ema Saavedra','Ema@gmail.com','123',1,1);

