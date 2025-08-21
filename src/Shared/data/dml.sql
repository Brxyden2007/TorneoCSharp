-- TORNEOS
INSERT INTO torneos (nombre, fecha_inicio, fecha_fin) VALUES
('Liga Apertura 2025', '2025-01-15', '2025-06-30'),
('Liga Clausura 2025', '2025-07-15', '2025-12-20');

-- EQUIPOS
INSERT INTO equipos (nombre, tipo, torneo_id) VALUES
('Atlético Nacional', 'Equipo Local', 1),
('Millonarios FC', 'Equipo Local', 1),
('Selección Colombia Sub-20', 'Selección', 1);

-- JUGADORES
INSERT INTO jugadores (nombre, edad, posicion) VALUES
('Juan Pérez', 22, 'Delantero'),
('Carlos Ramírez', 25, 'Defensa'),
('Andrés Gómez', 20, 'Mediocampista'),
('Luis Torres', 28, 'Portero');

-- ASIGNAR JUGADORES A EQUIPOS
INSERT INTO equipo_jugador (equipo_id, jugador_id) VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4);

-- TRANSFERENCIAS
INSERT INTO transferencias (jugador_id, equipo_origen_id, equipo_destino_id, fecha) VALUES
(1, 1, 2, '2025-02-10');

-- ESTADÍSTICAS
INSERT INTO estadisticas (jugador_id, goles, asistencias, tarjetas_amarillas, tarjetas_rojas) VALUES
(1, 5, 2, 1, 0),
(2, 0, 1, 3, 0),
(3, 2, 4, 0, 1),
(4, 0, 0, 0, 0);

-- CUERPO TÉCNICO
INSERT INTO cuerpostecnicos (nombre, rol, equipo_id) VALUES
('Pedro Martínez', 'Director Técnico', 1),
('José López', 'Asistente Técnico', 1),
('Raúl Herrera', 'Director Técnico', 2);

-- CUERPO MÉDICO
INSERT INTO cuerposmedicos (nombre, especialidad, equipo_id) VALUES
('Dr. Juan Pérez', 'Fisioterapeuta', 1),
('Dra. Carolina Gómez', 'Nutricionista', 1),
('Dr. Andrés Ramírez', 'Médico General', 2),
('Dra. Laura Martínez', 'Psicóloga Deportiva', 3);
