-- Eliminacion
DROP TABLE IF EXISTS comunas;
DROP TABLE IF EXISTS Regiones;
DROP TABLE IF EXISTS paises;

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