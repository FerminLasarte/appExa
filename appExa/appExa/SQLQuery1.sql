create table Usuarios
(
Nombre varchar(50) not null,
Apellido varchar(50) not null,
Email varchar(50) not null,
Usuario varchar(50) not null,
Contrasena varchar(50) not null
)

select * from Usuarios

insert into Usuarios values ('Prueba', 'Prueba', 'prueba@gmail.com', 'Prueba123', 'ConPrueba123');