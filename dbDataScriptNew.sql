USE [BookStore]
GO
SET IDENTITY_INSERT [dbo].[Authors] ON 

INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (8, N'Lav', N'Nikolajevic Tolstoj', CAST(N'2023-06-07T16:59:32.9666667' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (9, N'Nikolaj', N'Vasiljevic Gogolj', CAST(N'2023-06-07T16:59:46.7033333' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (10, N'Laza', N'Lazarevic', CAST(N'2023-06-07T19:09:10.0166667' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Authors] ([Id], [FirstName], [LastName], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (11, N'Jovan', N'Ducic', CAST(N'2023-07-07T22:42:49.5800000' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Authors] OFF
GO
SET IDENTITY_INSERT [dbo].[Covers] ON 

INSERT [dbo].[Covers] ([Id], [CoverType], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (1, N'Mekani', CAST(N'2023-08-23T15:04:17.5432373' AS DateTime2), NULL, CAST(N'2023-08-24T11:51:03.0710812' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Covers] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [Path], [Size], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (1, N'wwwroot\images\books\2ba00728-4853-465b-86b2-9865c20ebcf5.jpg', 0.15, CAST(N'2023-08-25T18:17:51.3266667' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Images] ([Id], [Path], [Size], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (2, N'wwwroot\images\books\2402d455-d2a5-4629-89e2-2a8a13614805.jpg', 0.2, CAST(N'2023-08-28T20:15:16.0900000' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Publishers] ON 

INSERT [dbo].[Publishers] ([Id], [Name], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (1, N'Laguna', CAST(N'2023-07-17T18:27:59.2866667' AS DateTime2), NULL, CAST(N'2023-07-17T16:52:11.7411442' AS DateTime2), 1)
INSERT [dbo].[Publishers] ([Id], [Name], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (2, N'Kosmos', CAST(N'2023-07-17T18:29:04.6733333' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[YearPublished] ON 

INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (35, 1990, CAST(N'2023-07-17T19:34:10.1889059' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (36, 2021, CAST(N'2023-07-17T19:34:10.3410439' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (37, 2020, CAST(N'2023-07-17T19:34:10.3410080' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (38, 2019, CAST(N'2023-07-17T19:34:10.3409625' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (39, 2018, CAST(N'2023-07-17T19:34:10.3409188' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (40, 2017, CAST(N'2023-07-17T19:34:10.3408825' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (41, 2016, CAST(N'2023-07-17T19:34:10.3408440' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (42, 2015, CAST(N'2023-07-17T19:34:10.3408027' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (43, 2014, CAST(N'2023-07-17T19:34:10.3407674' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (44, 2013, CAST(N'2023-07-17T19:34:10.3407287' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (45, 2012, CAST(N'2023-07-17T19:34:10.3406825' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (46, 2011, CAST(N'2023-07-17T19:34:10.3406479' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (47, 2010, CAST(N'2023-07-17T19:34:10.3406118' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (48, 2009, CAST(N'2023-07-17T19:34:10.3405704' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (49, 2008, CAST(N'2023-07-17T19:34:10.3405339' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (50, 2007, CAST(N'2023-07-17T19:34:10.3404894' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (51, 2006, CAST(N'2023-07-17T19:34:10.3404537' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (52, 2005, CAST(N'2023-07-17T19:34:10.3404129' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (53, 1991, CAST(N'2023-07-17T19:34:10.3390527' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (54, 1992, CAST(N'2023-07-17T19:34:10.3398283' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (55, 1993, CAST(N'2023-07-17T19:34:10.3398814' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (56, 1994, CAST(N'2023-07-17T19:34:10.3399367' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (57, 1995, CAST(N'2023-07-17T19:34:10.3399795' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (58, 1996, CAST(N'2023-07-17T19:34:10.3400186' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (59, 2022, CAST(N'2023-07-17T19:34:10.3410857' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (60, 1997, CAST(N'2023-07-17T19:34:10.3400689' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (61, 1999, CAST(N'2023-07-17T19:34:10.3401582' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (62, 2000, CAST(N'2023-07-17T19:34:10.3401992' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (63, 2001, CAST(N'2023-07-17T19:34:10.3402360' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (64, 2002, CAST(N'2023-07-17T19:34:10.3402774' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (65, 2003, CAST(N'2023-07-17T19:34:10.3403148' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (66, 2004, CAST(N'2023-07-17T19:34:10.3403580' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (67, 1998, CAST(N'2023-07-17T19:34:10.3401122' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (68, 2023, CAST(N'2023-07-17T19:34:10.3411218' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[YearPublished] ([Id], [Year], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (69, 1989, CAST(N'2023-07-17T20:41:37.5239367' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[YearPublished] OFF
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([Id], [Name], [NumberOfPages], [Description], [QuantityInStock], [Price], [PublisherId], [PublishYearId], [CoverId], [ImageId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (1, N'Blago cara Radovana', 394, N'Klasici srpske književnosti.

Knjiga o sudbini.''nSvi ljudi znaju da ima u životu još uvek jedno zakopano blago za svakog od njih. Svi ljudi kopaju: svi ljudi od akcije, od poleta, od sile, od vere u život i u cilj, i od vere u neverovatno i u nemogućno. Svi traže i vape za carem tog večnog nespokojstva i večnog traganja. Svet bi nestao da nema tog cara, i oslepio bi da ne sija u pomrčini njegovo naslućeno blago...
Knjiga mudrosti i lepote velikog srpskog pesnika, jedno od najčitanijih dela srpske književnosti. Riznica poetičnih filozofskih razmatranja o sudbinskim temama koje zaokupljaju svakog čoveka. Izvor znanja i životnog nadahnuća. Knjiga koja generacije čitalaca podstiče na razmišljanje, pruža podršku u teškim trenucima i pomaže svakome ko uroni u njene redove da lakše pronađe svoj put.

O sreći ▪ ljubavi ▪ ženi ▪ prijateljstvu ▪ mladosti i starosti ▪ pesniku ▪ herojima ▪ kraljevima ▪ prorocima', 425, CAST(999.00 AS Decimal(8, 2)), 1, 68, 1, 1, CAST(N'2023-08-25T18:17:51.4200000' AS DateTime2), NULL, CAST(N'2023-08-25T22:20:43.3906687' AS DateTime2), 1)
INSERT [dbo].[Books] ([Id], [Name], [NumberOfPages], [Description], [QuantityInStock], [Price], [PublisherId], [PublishYearId], [CoverId], [ImageId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (5, N'Ana Karenjina', 896, N'„Najbolja knjiga svih vremena.“ Washington PostSve srećne porodice liče jedna na drugu, svaka nesrećna porodica nesrećna je na svoj način.Roman koji je Fjodor Dostojevski smatrao besprekornim, a Vilijam Fokner nazvao najboljim romanom koji je ikada napisan, Ana Karenjina je monumentalno delo Lava Tolstoja koji daje sveobuhvatan prikaz ruskog društva devetnaestog veka, od aristokratskih salona do seoskih gazdinstava. Uvodeći dva narativna toka, prvi koji prati ljubavnu priču između Ane i Vronskog i drugi koji prati odnos između Kiti i Ljevina, Lav Tolstoj ispisuje svevremene stranice o porodici, gubitku, ljubavi, izdaji, veri i prijateljstvu.„U Ani Karenjini Tolstoj je dao izuzetnu psihološku analizu ljudske duše, vrlo duboko i snažno, s realizmom umetničkog opisivanja koji dosad nismo imali.“ Fjodor Dostojevski„Najveći društveni roman čitave svetske književnosti.“ Tomas Man „Jedna od najvećih ljubavnih priča u svetskoj književnosti.“ Vladimir Nabokov', 380, CAST(1400.00 AS Decimal(8, 2)), 1, 65, 1, 2, CAST(N'2023-08-28T18:15:15.5507497' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (5, 8)
INSERT [dbo].[BookAuthors] ([BookId], [AuthorId]) VALUES (1, 11)
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (3, N'Roman', CAST(N'2023-07-16T17:49:38.2200000' AS DateTime2), NULL, CAST(N'2023-07-16T22:12:49.0654015' AS DateTime2), 1)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (4, N'Horor', CAST(N'2023-07-16T18:42:19.3066667' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Genres] ([Id], [Name], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (5, N'Putopis', CAST(N'2023-07-16T18:44:38.5733333' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
INSERT [dbo].[BookGenres] ([BookId], [GenreId]) VALUES (5, 3)
INSERT [dbo].[BookGenres] ([BookId], [GenreId]) VALUES (1, 4)
INSERT [dbo].[BookGenres] ([BookId], [GenreId]) VALUES (5, 4)
INSERT [dbo].[BookGenres] ([BookId], [GenreId]) VALUES (1, 5)
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive], [IsDefault]) VALUES (1, N'User', CAST(N'2023-06-07T23:01:34.2933333' AS DateTime2), NULL, NULL, 1, 1)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive], [IsDefault]) VALUES (2, N'Administrator', CAST(N'2023-06-07T23:01:42.7833333' AS DateTime2), NULL, NULL, 1, 0)
INSERT [dbo].[Roles] ([Id], [Name], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive], [IsDefault]) VALUES (3, N'Moderator', CAST(N'2023-06-07T23:01:47.6633333' AS DateTime2), NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [Username], [LastName], [Email], [Password], [RoleId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (2, N'Aleksa', N'Pantelija', N'Pantic', N'aleksapantic@gmail.com', N'$2a$12$0R/jxc9GpQ0RU4y6.zmRSe4IPqrXctpqLDgq.ku2i2mLWyVBJgGqu', 2, CAST(N'2023-08-26T16:14:26.1966667' AS DateTime2), NULL, CAST(N'2023-08-26T15:44:02.6015754' AS DateTime2), 1)
INSERT [dbo].[Users] ([Id], [FirstName], [Username], [LastName], [Email], [Password], [RoleId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (3, N'Moderni', N'Moderator1', N'Moderator', N'moderator@gmail.com', N'$2b$10$bPEvAQx0z82Nl2e.Qve/yOLEuNyr6e3BHlbD4vXqmDsXbADdtjoYG', 3, CAST(N'2023-08-30T21:48:28.2172205' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[Users] ([Id], [FirstName], [Username], [LastName], [Email], [Password], [RoleId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (5, N'Mika', N'Korisnik', N'Mikic', N'user@gmail.com', N'$2b$10$J4ZsmwNoXF8pISpcA55vhOo6dRcGBqWeue180gqDTNdwWtwpZMOK6', 1, CAST(N'2023-08-30T22:37:39.6117063' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [OrderDate], [Address], [OrderStatus], [UserId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (5, CAST(N'2023-08-29T00:00:00.0000000' AS DateTime2), N'Celopecka 11, Beograd', 3, 2, CAST(N'2023-08-29T18:23:21.1038308' AS DateTime2), CAST(N'2023-08-29T21:06:03.8465942' AS DateTime2), NULL, 1)
INSERT [dbo].[Orders] ([Id], [OrderDate], [Address], [OrderStatus], [UserId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (6, CAST(N'2023-08-29T00:00:00.0000000' AS DateTime2), N'Celopecka 11, Beograd', 0, 2, CAST(N'2023-08-29T18:34:05.9143076' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[Cart] ON 

INSERT [dbo].[Cart] ([Id], [UserId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (1, 2, CAST(N'2023-08-28T20:53:34.1880533' AS DateTime2), NULL, CAST(N'2023-08-28T21:51:16.2365966' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Cart] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderBooks] ON 

INSERT [dbo].[OrderBooks] ([Id], [BookName], [Quantity], [Price], [BookId], [OrderId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (6, N'Blago cara Radovana', 5, CAST(999.00 AS Decimal(18, 2)), 1, 5, CAST(N'2023-08-29T18:23:21.4098881' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[OrderBooks] ([Id], [BookName], [Quantity], [Price], [BookId], [OrderId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (7, N'Blago cara Radovana', 5, CAST(999.00 AS Decimal(18, 2)), 1, 6, CAST(N'2023-08-29T18:34:06.1949021' AS DateTime2), NULL, NULL, 1)
INSERT [dbo].[OrderBooks] ([Id], [BookName], [Quantity], [Price], [BookId], [OrderId], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (8, N'Ana Karenjina', 10, CAST(1400.00 AS Decimal(18, 2)), 5, 6, CAST(N'2023-08-29T18:34:06.2573910' AS DateTime2), NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[OrderBooks] OFF
GO
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 1)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 5)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 9)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 13)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 15)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 19)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 20)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 27)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 31)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 34)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 35)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 36)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 37)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 38)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (1, 39)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 1)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 2)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 3)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 4)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 5)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 6)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 7)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 8)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 9)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 10)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 11)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 12)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 13)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 14)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 15)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 16)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 17)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 18)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 19)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 20)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 21)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 22)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 23)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 24)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 25)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 26)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 27)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 28)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 29)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 30)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 31)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 32)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 33)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 34)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 35)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 36)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 37)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 38)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 39)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 40)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 41)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (2, 42)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 1)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 2)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 3)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 4)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 5)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 6)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 7)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 8)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 9)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 10)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 11)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 12)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 13)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 14)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 15)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 16)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 17)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 18)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 19)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 20)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 21)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 22)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 23)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 24)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 25)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 26)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 27)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 28)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 29)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 31)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 34)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 35)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 36)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 37)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 38)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 39)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 40)
INSERT [dbo].[RoleUseCases] ([RoleId], [UseCaseId]) VALUES (3, 41)
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230606195317_initial', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230606195804_fixedCartBooks', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230606215438_addedRoles', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607145634_fixedDeletedAt', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607145909_fixedNullable', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607205914_logEntriesAdded', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230825152321_changed size in image', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230826133333_uniqueusername', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230829142125_priceFixed', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230830192344_passwordFixed', N'5.0.17')
GO
SET IDENTITY_INSERT [dbo].[LogEntries] ON 

INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (1, N'Pantelija', 2, N'Get books', N'{"BookName":null,"MinPrice":null,"MaxPrice":null,"Available":false,"PublisherId":null,"CoverId":null,"GenresIds":null,"AuthorsIds":null,"PerPage":10,"Page":1}', CAST(N'2023-08-30T20:45:14.0669162' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (2, N'Pantelija', 2, N'Get books', N'{"BookName":null,"MinPrice":null,"MaxPrice":null,"Available":false,"PublisherId":null,"CoverId":null,"GenresIds":null,"AuthorsIds":null,"PerPage":10,"Page":1}', CAST(N'2023-08-30T20:50:41.1298860' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (3, N'Pantelija', 2, N'Get orders', N'{"UserId":2,"OrderId":null}', CAST(N'2023-08-30T20:51:05.8070295' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (4, N'Pantelija', 2, N'Get orders', N'{"UserId":2,"OrderId":null}', CAST(N'2023-08-30T20:51:10.8601417' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (5, N'unauthorize', 0, N'Get books', N'{"BookName":null,"MinPrice":null,"MaxPrice":null,"Available":false,"PublisherId":null,"CoverId":null,"GenresIds":null,"AuthorsIds":null,"PerPage":10,"Page":1}', CAST(N'2023-08-30T21:02:15.6545393' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (6, N'unauthorize', 0, N'Search year published', N'null', CAST(N'2023-08-30T21:05:28.8101199' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (7, N'unauthorize', 0, N'Get books', N'{"BookName":null,"MinPrice":null,"MaxPrice":null,"Available":false,"PublisherId":null,"CoverId":null,"GenresIds":null,"AuthorsIds":null,"PerPage":10,"Page":1}', CAST(N'2023-08-30T21:08:06.4285231' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (8, N'unauthorize', 0, N'Get book by id', N'1', CAST(N'2023-08-30T21:08:17.6642957' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (9, N'Pantelija', 2, N'Search log', N'{"ActorId":null,"ActorUserName":null,"UseCaseKeyword":"search"}', CAST(N'2023-08-30T21:42:38.8015800' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (10, N'Pantelija', 2, N'Search log', N'{"ActorId":null,"ActorUserName":null,"UseCaseKeyword":"search"}', CAST(N'2023-08-30T21:44:00.0918439' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (11, N'Pantelija', 2, N'Search log', N'{"ActorId":null,"ActorUserName":null,"UseCaseKeyword":"search"}', CAST(N'2023-08-30T21:45:02.3962678' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (12, N'Pantelija', 2, N'Search log', N'{"ActorId":null,"ActorUserName":null,"UseCaseKeyword":"search"}', CAST(N'2023-08-30T21:45:53.4074257' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (13, N'unauthorize', 0, N'Register user', N'{"UserName":"Moderator1","FirstName":"Moderni","LastName":"Moderator","Email":"moderator@gmail.com","Password":"lozinka"}', CAST(N'2023-08-30T21:48:27.3753002' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (14, N'unauthorize', 0, N'Search authors', N'{"Keyword":null}', CAST(N'2023-08-30T22:08:32.7562908' AS DateTime2), NULL, NULL, 0)
INSERT [dbo].[LogEntries] ([Id], [Actor], [ActorId], [UseCaseName], [UseCaseData], [CreatedAt], [DeletedAt], [ModifiedAt], [IsActive]) VALUES (15, N'unauthorize', 0, N'Register user', N'{"UserName":"Korisnik","FirstName":"Mika","LastName":"Mikic","Email":"user@gmail.com","Password":"lozinka"}', CAST(N'2023-08-30T22:37:38.8965799' AS DateTime2), NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[LogEntries] OFF
GO
