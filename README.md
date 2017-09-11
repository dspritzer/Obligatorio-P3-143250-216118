# Obligatorio-P3-143250-216118

script para la base de datos:

use nuevaprueba
drop table Calificacion
drop table EventoProvServ
drop table Evento
drop table Proveedor
drop table Organizador
drop table Usuario
drop table TipoUser
drop table Servicio
drop table TipoServicio_Eventos
drop table TipoServicio
drop table TipoEvento

CREATE TABLE TipoEvento(idTipoEvento int identity(1,1),
     nombre varchar(30),
     descripcion varchar(100),
     CONSTRAINT PK_TipoEv Primary Key(idTipoEvento))

CREATE TABLE TipoServicio(
 idTipoServicio int identity(1,1),
 nombre varchar(20),
 constraint PK_TipoServicio primary key (idTipoServicio))

CREATE TABLE TipoServicio_Eventos(
 idTipoServicio int identity(1,1),
 idTipoEvento int,
 constraint PK_TipoServEvento primary key (idTipoServicio,idTipoEvento),
 constraint FK_TServEvento foreign key (idTipoServicio) references TipoServicio(idTipoServicio),
 constraint FK_TEvento foreign key (idTipoEvento) references TipoEvento(idTipoEvento))
 
CREATE TABLE Servicio(idServ int identity(1,1),
    nombre varchar(30),
 descripcion varchar(80),
 foto varchar(100),
    idTipoServ int,
    Constraint PK_SERV primary key (idServ),
    Constraint FK_TipoEv foreign key (idTipoServ) references TipoServicio(idTipoServicio))

CREATE TABLE TipoUser(idTipoUser numeric(5),
    nombre varchar(30),
    Constraint PK_TipoUser primary Key (idTipoUser))
 
CREATE TABLE Usuario(idUsuario int identity(1,1),
    username varchar(30),
    pass varchar(30),
    idTipoUser numeric(5),
    Constraint PK_USER primary key (idUsuario),
    constraint FK_UserT foreign key (idTipoUser) references TipoUser(idTipoUSer))
 
CREATE TABLE Organizador(idOrganizador int identity(1,1),
	idUsuario int,
    nombre varchar(30),
    email varchar(50),
    telefono varchar(15),
    Constraint PK_ORGA primary key (idOrganizador),
	constraint UQ_mail Unique (email),
    constraint fk_orga foreign key (idUsuario) references Usuario(idUsuario))
 
CREATE TABLE Proveedor(idProveedor int identity(1,1),
	idUsuario int,
    RUT varchar(12),
    nombreFantasia varchar(50),
    email varchar(50),
    telefono varchar(15),
    fechaReg Date,
    activo bit,
    VIP bit,
    calificacion numeric(5,2),
    constraint pk_prov primary key (idProveedor),
	constraint uq_rut unique (RUT),
    constraint fk_prov foreign key (idUsuario) references Usuario(idUsuario))
 
 
CREATE TABLE Evento(idEvento int identity(1,1),
    idTipoEvento int,
    fechaEvento Date,
    direccion varchar(50),
    constraint PK_Evento primary key (idEvento),
    constraint fk_TEv foreign key (idTipoEvento) references TipoEvento(idTipoEvento))
 
CREATE TABLE EventoProvServ(idEvento int,
    RUT varchar(12),
    idServ int,
    constraint PK_EPS primary key (idEvento,RUT,idServ),
    constraint fk_EPS1 foreign key (RUT) references Proveedor(RUT),
    constraint fk_EPS2 foreign key (idServ) references Servicio(idServ))
 
CREATE TABLE Calificacion(idCalificacion int identity(1,1),
    idOrganizador int,
    idProveedor int,
    valor numeric(5),
    comentario varchar(140),
    constraint pk_calif primary key (idCalificacion),
    constraint fk_calO foreign key (idOrganizador) references Organizador(idOrganizador),
    constraint fk_calP foreign key (idProveedor) references Proveedor(idProveedor))
