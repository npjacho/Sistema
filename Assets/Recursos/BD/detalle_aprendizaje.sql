CREATE TABLE `detalle_aprendizaje` (
	`id_detalle_apre`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	`num_repeticiones`	INTEGER,
	`velocidad_detalle_apre`	INTEGER,
	`tiempo_reaccion`	TEXT,
	`tiempo_cuadro`	TEXT,
	`tiempo_boton`	TEXT,
	`id_aprendizaje`	INTEGER,
	`id_ubicacion`	INTEGER,
	`id_color`	INTEGER,
	`id_personaje`	INTEGER,
	`observacion_detalle_apre`	INTEGER,
	foreign key (id_aprendizaje) references aprendizaje (id_aprendizaje),
	foreign key (id_ubicacion) references ubicacion (id),
	foreign key (id_color) references color (id),
	foreign key (id_personaje) references personaje (id_personaje)
);