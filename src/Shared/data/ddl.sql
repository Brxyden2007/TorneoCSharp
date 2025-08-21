DROP DATABASE IF EXISTS torneodb;
CREATE DATABASE IF NOT EXISTS torneodb;
USE torneodb;

-- TORNEOS
CREATE TABLE torneos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NOT NULL
);

-- EQUIPOS
CREATE TABLE equipos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    tipo VARCHAR(50) NOT NULL, -- Selección o Equipo Local
    torneo_id INT NOT NULL,
    FOREIGN KEY (torneo_id) REFERENCES torneos(id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- JUGADORES
CREATE TABLE jugadores (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    edad INT NOT NULL,
    posicion VARCHAR(50) NOT NULL
);

-- TABLA INTERMEDIA EQUIPO-JUGADOR
CREATE TABLE equipo_jugador (
    equipo_id INT NOT NULL,
    jugador_id INT NOT NULL,
    PRIMARY KEY (equipo_id, jugador_id),
    FOREIGN KEY (equipo_id) REFERENCES equipos(id) ON DELETE CASCADE,
    FOREIGN KEY (jugador_id) REFERENCES jugadores(id) ON DELETE CASCADE
);

-- TRANSFERENCIAS
CREATE TABLE transferencias (
    id INT PRIMARY KEY AUTO_INCREMENT,
    jugador_id INT NOT NULL,
    equipo_origen_id INT NOT NULL,
    equipo_destino_id INT NOT NULL,
    fecha_transferencia DATE NOT NULL,
    monto DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (jugador_id) REFERENCES jugadores(id) ON DELETE CASCADE,
    FOREIGN KEY (equipo_origen_id) REFERENCES equipos(id) ON DELETE CASCADE,
    FOREIGN KEY (equipo_destino_id) REFERENCES equipos(id) ON DELETE CASCADE
);

-- ESTADÍSTICAS
CREATE TABLE estadisticas (
    id INT PRIMARY KEY AUTO_INCREMENT,
    jugador_id INT NOT NULL,
    goles INT DEFAULT 0,
    asistencias INT DEFAULT 0,
    tarjetas_amarillas INT DEFAULT 0,
    tarjetas_rojas INT DEFAULT 0,
    FOREIGN KEY (jugador_id) REFERENCES jugadores(id) ON DELETE CASCADE
);

-- CUERPO TÉCNICO
CREATE TABLE cuerpostecnicos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    rol VARCHAR(100) NOT NULL,
    equipo_id INT NOT NULL,
    FOREIGN KEY (equipo_id) REFERENCES equipos(id) ON DELETE CASCADE
);

-- CUERPO MÉDICO
CREATE TABLE cuerposmedicos (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    especialidad VARCHAR(100) NOT NULL,
    equipo_id INT NOT NULL,
    FOREIGN KEY (equipo_id) REFERENCES equipos(id) ON DELETE CASCADE
);
