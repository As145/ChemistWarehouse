INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3491318f-57f9-4808-81a6-dababd3361c8', N'admin', N'admin', N'c14ebf4f-14e3-4951-a32e-331a8d509ed7')
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'397d0434-df4b-4c52-8704-2e5072b91161', N'mia@gmail.com', N'MIA@GMAIL.COM', N'mia@gmail.com', N'MIA@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEP4M31N2TE9oFuSqQvzryD0JGV+YU3o9/XKM/1URXHo3aqUA4B7YFWWD4OmNHjQMKA==', N'HFQCK4UM7MAYNCWCBBIWT6AMDUYMDIFI', N'921a8f49-4ce7-4d7b-b203-a4d545950e00', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'70c23d8e-0ff3-4969-b523-f413442bae1a', N'admin@chemistwarehouse.com', N'ADMIN@CHEMISTWAREHOUSE.COM', N'admin@chemistwarehouse.com', N'ADMIN@CHEMISTWAREHOUSE.COM', 1, N'AQAAAAEAACcQAAAAEJ5Q0RPFys2Srd5W1LqD2voTdWgwz5dGBj+gC1Z5pPV2soIhvWfRpVBd/qje8Lr7yQ==', N'4BATYY7ZXT3VREYNEKLATYZTLWPVJUUO', N'08e8b8a2-f0a9-470b-966e-fe5ba96143b9', NULL, 0, 0, NULL, 1, 0)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'70c23d8e-0ff3-4969-b523-f413442bae1a', N'3491318f-57f9-4808-81a6-dababd3361c8')
GO
SET IDENTITY_INSERT [dbo].[Carts] ON 
GO
INSERT [dbo].[Carts] ([CartID], [UserID], [CartDate], [CartStatus], [OrderDate], [Address], [ContactNo]) VALUES (1, N'mia@gmail.com', CAST(N'2021-11-14T17:27:11.0000000' AS DateTime2), N'Order', CAST(N'2021-11-14T17:40:37.2488455' AS DateTime2), N'Near Apsa Hospital, Auckland', N'1245568989')
GO
SET IDENTITY_INSERT [dbo].[Carts] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (1, N'Skin Care')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (2, N'Vitamins & Supplements')
GO
INSERT [dbo].[Categories] ([CategoryID], [CategoryName]) VALUES (3, N'Medicines')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductInfos] ON 
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (1, N'Dermal Therapy Lip Balm 10g', 5.49, 4.49, N'Urea (2.5%), Petrolatum, Glyceryl Stearate, Behenyl Alcohol, Palmitic Acid, Stearic Acid, Lecithin, Lauryl Alcohol, Myristyl Alcohol, Cetyl Alochol, Aqua, Theobroma Cocao, Seed Butter,Lanolin, Cetyl Esters, Camphor Menthol, MEthylparaben, BHA, Eugenia Caryophyllus (Clove) LEaf Oil, Sucralose, Propylparaben, Aroma, Eugenol.', 1, N'.jpg')
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (2, N'Martin & Pleasance Arnica Cream 100g', 9.99, 8.49, N'Traditionally used in herbal medicine for the temporary relief of bruising, minor sprains, and sporting injuries.', 1, N'.jpg')
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (3, N'L''Oreal Paris Revitalift Laser X3 Day Cream 50ml', 44.49, 31.19, N'L''Oreal Paris has developed an anti-ageing skincare routine to challenge a laser session. Revitalift X3 Day Cream is a powerful anti-ageing everyday moisturiser that corrects wrinkles, re-densifies your skin and re-supports your contours. Containing wrinkle correcting ingredients Hyaluronic Acid and Pro-xylane for deep anti-aging care.', 1, N'.jpg')
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (4, N'Berocca 50+ Energy Vitamin With Ginseng Effervescent Tablets 30 pack', 22.99, 19.99, N'An effervescent energy multivitamin, with added ginseng, to help support mental sharpness and physical energy throughout the day for those aged 50 years +. Berocca 50+ Energy Vitamin is a unique combination of B vitamins, vitamin C and essential minerals, like calcium, magnesium, and zinc, together with added natural ginseng. This multivitamin is tailored to meet the needs of those 50 years and over. Taken daily, Berocca 50+ Energy Vitamin may help improve your mental alertness and physical energy throughout the day. - Effervescent format. - Great tasting Orange flavour. - Suitable for everyday use. - Helps improve alertness and concentration. - Helps improve physical stamina and reduce tiredness and fatigue - Helps enhance mental performance. - Helps improve mood and reduce tiredness.', 2, N'.jpg')
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (5, N'Blackmores Odourless Fish Oil 400 Mini Capsules', 35.59, 30.89, N'High quality fish oil, made odourless and reflux-free with great tasting natural lemon and vanilla flavouring. A rich source of the omega-3 essential fatty acids EPA and DHA for joint, heart, eye, brain and skin health. High quality fish oil made odourless and reflux-free without the use of artificial surfactants or additives', 2, N'.jpg')
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (6, N'Zovirax Cold Sore Cream Tube 2g', 20.99, 15.99, N'Zovirax Cold Sore Cream has a patented formula which delivers up to 5 times move of the available active ingredient, aciclovir, than some generic aciclovir creams.', 2, N'.jpg')
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (7, N'Acuvue Revitalens Solution 100ml', 10.49, 8.99, N'Acuvue RevitaLens Multi-Purpose Disinfecting Solution is an exceptional disinfection and all-day comfort. Its cleans, conditions, removes protein, rinses, disinfects and stores soft contact lenses, including silicone hydrogel lenses.', 3, N'.jpg')
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (8, N'Acuvue Revitalens Solution Twin Pack 2 X 300ml', 30.99, 25.99, N'Acuvue RevitaLens Multi-Purpose Disinfecting Solution is an exceptional disinfection and all-day comfort. Its cleans, conditions, removes protein, rinses, disinfects and stores soft contact lenses, including silicone hydrogel lenses.', 3, N'.jpg')
GO
INSERT [dbo].[ProductInfos] ([ProductID], [ProductName], [Price], [SalePrice], [Description], [CategoryID], [Extension]) VALUES (9, N'Refresh Tears Plus 15mL', 12.99, 10.99, N'Dry Eye is a condition that occurs when your eyes either produce too few tears or the quality of your tears are poor. This can cause dryness, discomfort and may interfere with vision.', 3, N'.jpg')
GO
SET IDENTITY_INSERT [dbo].[ProductInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[CartItems] ON 
GO
INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ProductID], [Price], [Quantity], [Total]) VALUES (1, 1, 5, 30.89, 1, 30.89)
GO
INSERT [dbo].[CartItems] ([CartItemID], [CartID], [ProductID], [Price], [Quantity], [Total]) VALUES (2, 1, 4, 19.99, 1, 19.99)
GO
SET IDENTITY_INSERT [dbo].[CartItems] OFF
GO