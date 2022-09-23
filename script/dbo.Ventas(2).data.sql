SET IDENTITY_INSERT [dbo].[Ventas] ON
INSERT INTO [dbo].[Ventas] ([Id], [ClienteId], [ProductosId], [FechaVenta]) VALUES (1, 1, 1, N'2000-03-20 00:00:00')
INSERT INTO [dbo].[Ventas] ([Id], [ClienteId], [ProductosId], [FechaVenta]) VALUES (3, 2, 2, N'2000-03-21 00:00:00')
DELETE FROM Ventas where Id = 3
SET IDENTITY_INSERT [dbo].[Ventas] OFF
