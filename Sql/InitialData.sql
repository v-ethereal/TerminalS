GO
INSERT [dbo].[CustomizationData] ([Key], [Value]) VALUES (N'Message.CanLoginException', N'Вход в систему не возможен')
INSERT [dbo].[CustomizationData] ([Key], [Value]) VALUES (N'Message.CanPayException', N'Оплата за данное место невозможна')
INSERT [dbo].[CustomizationData] ([Key], [Value]) VALUES (N'Message.LoginException', N'Неверный логин/пароль')
INSERT [dbo].[CustomizationData] ([Key], [Value]) VALUES (N'Message.EmptyLogin', N'Введите логин')
INSERT [dbo].[CustomizationData] ([Key], [Value]) VALUES (N'Message.PayInformation', N'* Возврат денег невозможен;* Автомат сдачу не дает;* Зачет оплаты производится автоматически при наборе необходимой суммы;* Частичная оплата аренды производится как платеж за прочие услуги;* Остаток введенных денег (сдача) проводится как платеж за прочие услуги;* Принимаются купюры достоинством <%NOMINALS%> руб.')

GO
SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT [dbo].[Roles] ([Id], [Name], [Description]) VALUES (1, N'SystemAdmin', N'Администратор системы')
INSERT [dbo].[Roles] ([Id], [Name], [Description]) VALUES (2, N'Accountant', N'Бухгатлтер')
INSERT [dbo].[Roles] ([Id], [Name], [Description]) VALUES (3, N'CommercialAdmin', N'Администартор торгового зала')
SET IDENTITY_INSERT [dbo].[Roles] OFF

GO
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT [dbo].[Users] ([Id], [Login], [Password], [Name]) VALUES (1, N'admin', 0xB081DBE85E1EC3FFC3D4E7D0227400CD, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF