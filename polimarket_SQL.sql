/*
Created		2/14/2022
Modified		2/14/2022
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2005 
*/

/*
create database db_polimarket
go
*/

Create table [Usuario]
(
	[idUsuario] Integer IDENTITY(1,1) NOT NULL,
	[nombre] Char(45) NOT NULL,
	[apellido] Char(45) NOT NULL,
	[direccion] Char(100) NOT NULL,
	[email] Char(45) NOT NULL,
	[password] Char(45) NOT NULL,
Constraint [pk_Usuario] Primary Key ([idUsuario])
) 
go

Create table [Usuario_Rol]
(
	[idUsuarioRol] Integer IDENTITY(1,1) NOT NULL,
	[idUsuario] Integer NOT NULL,
	[idRol] Integer NOT NULL
Constraint [pk_Usuario_Rol] Primary Key ([idUsuarioRol])
) 
go

Create table [Rol]
(
	[idRol] Integer IDENTITY(1,1) NOT NULL,
	[nombre] Char(45) NOT NULL,
Constraint [pk_Rol] Primary Key ([idRol])
) 
go

Create table [Rol_Permiso]
(
	[idRolPermiso] Integer IDENTITY(1,1) NOT NULL,
	[idRol] Integer NOT NULL,
	[idPermiso] Integer NOT NULL
Constraint [pk_Rol_Permiso] Primary Key ([idRolPermiso])
) 
go

Create table [Permiso]
(
	[idPermiso] Integer IDENTITY(1,1) NOT NULL,
	[nombre] Char(45) NOT NULL,
Constraint [pk_Permiso] Primary Key ([idPermiso])
) 
go

Create table [TarjetaCredito]
(
	[idTarjetaCredito] Integer IDENTITY(1,1) NOT NULL,
	[numero] Char(16) NOT NULL,
	[entidadBancaria] Char(45) NOT NULL,
	[idUsuario] Integer NOT NULL,
Constraint [pk_TarjetaCredito] Primary Key ([idTarjetaCredito])
) 
go

Create table [Sucursal]
(
	[idSucursal] Integer IDENTITY(1,1) NOT NULL,
	[direccion] Char(100) NOT NULL,
	[idUsuario] Integer NOT NULL,
Constraint [pk_Sucursal] Primary Key ([idSucursal])
) 
go

Create table [Pedido]
(
	[idPedido] Integer IDENTITY(1,1) NOT NULL,
	[fechaPedido] Datetime NOT NULL,
	[estado] Char(45) NOT NULL,
	[idUsuario] Integer NOT NULL,
Constraint [pk_Pedido] Primary Key ([idPedido])
) 
go

Create table [Pedido_Detalle]
(
	[idCompra] Integer IDENTITY(1,1) NOT NULL,
	[cantidad] Integer NOT NULL,
	[valorTotal] Float NOT NULL,
	[idPedido] Integer NOT NULL,
	[idProducto] Integer NOT NULL,
Constraint [pk_Pedido_Detalle] Primary Key ([idCompra])
) 
go

Create table [Producto]
(
	[idProducto] Integer IDENTITY(1,1) NOT NULL,
	[nombre] Char(60) NOT NULL,
	[codigo] Char(20) NOT NULL,
	[precio] Float NOT NULL,
	[idCategoria] Integer NOT NULL,
Constraint [pk_Producto] Primary Key ([idProducto])
) 
go

Create table [Categoria]
(
	[idCategoria] Integer IDENTITY(1,1) NOT NULL,
	[nombre] Char(45) NOT NULL,
Constraint [pk_Categoria] Primary Key ([idCategoria])
) 
go

Create table [Sucursal_Producto]
(
	[idSucursalProducto] Integer IDENTITY(1,1) NOT NULL,
	[stock] Integer NOT NULL,
	[idSucursal] Integer NOT NULL,
	[idProducto] Integer NOT NULL
Constraint [pk_Sucursal_Producto] Primary Key ([idSucursalProducto])
) 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


