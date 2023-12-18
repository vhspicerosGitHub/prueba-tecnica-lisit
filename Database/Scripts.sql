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
