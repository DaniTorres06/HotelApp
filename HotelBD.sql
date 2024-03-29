USE [HotelDB]
GO
/****** Object:  Table [dbo].[Booking]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Booking](
	[IdBooking] [int] IDENTITY(1,1) NOT NULL,
	[IdPassenger] [int] NOT NULL,
	[IdHotel] [int] NOT NULL,
	[IdRoom] [int] NOT NULL,
	[DateInitial] [date] NOT NULL,
	[DateFinal] [date] NOT NULL,
	[ReservetionState] [int] NOT NULL,
	[CostTotal] [decimal](18, 0) NOT NULL,
	[PaymentForm] [smallint] NOT NULL,
	[Notas] [varchar](200) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotels]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotels](
	[IdHotel] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[RoomsNumber] [int] NOT NULL,
	[Phone] [float] NOT NULL,
	[State] [smallint] NOT NULL,
 CONSTRAINT [PK_Hotels] PRIMARY KEY CLUSTERED 
(
	[IdHotel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[IdPassenger] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Birthdate] [date] NOT NULL,
	[Genero] [smallint] NOT NULL,
	[DocumentType] [int] NOT NULL,
	[DocumentNumber] [bigint] NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Phone] [bigint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[IdRol] [int] IDENTITY(1,1) NOT NULL,
	[TypeRol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[IdRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[IdBedRoom] [int] IDENTITY(1,1) NOT NULL,
	[NumberRoom] [int] NOT NULL,
	[State] [smallint] NOT NULL,
	[TypeRoom] [int] NOT NULL,
	[ReservetionState] [smallint] NOT NULL,
	[CostBase] [decimal](18, 0) NOT NULL,
	[CostTotal] [decimal](18, 0) NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[TaxAmount] [decimal](18, 0) NULL,
	[IdHotel] [int] NOT NULL,
 CONSTRAINT [PK_Bedrooms] PRIMARY KEY CLUSTERED 
(
	[IdBedRoom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomsType]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomsType](
	[IdType] [int] IDENTITY(1,1) NOT NULL,
	[TypeBedrooms] [varchar](50) NOT NULL,
	[Capacity] [int] NOT NULL,
 CONSTRAINT [PK_BedRoomsType] PRIMARY KEY CLUSTERED 
(
	[IdType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[UserDesc] [varchar](50) NOT NULL,
	[Pass] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IdRol] [int] NOT NULL,
	[State] [smallint] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Bedrooms_Hotels] FOREIGN KEY([IdHotel])
REFERENCES [dbo].[Hotels] ([IdHotel])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Bedrooms_Hotels]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Rol] FOREIGN KEY([IdRol])
REFERENCES [dbo].[Rol] ([IdRol])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Rol]
GO
/****** Object:  StoredProcedure [dbo].[Bedrooms_add]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Bedrooms_add]

@NumberRoom int,
@TypeRoom int,
@State int,
@Price decimal(18,0),
@IdHotel smallint,
@ReservetionState smallint

as
begin

declare @Has_error int
declare @IdRoute int

set @Has_error = 0

	insert into dbo.Bedrooms
	(
		NumberRoom,
		TypeRoom,
		State,
		Price,
		IdHotel,
		ReservetionState
	) 	
	VALUES
	(
		@NumberRoom,
		@TypeRoom,
		@State,
		@Price,
		@IdHotel,
		@ReservetionState
	)

	SET @IdRoute = (SELECT scope_identity());

	IF (@IdRoute <> 0)
	begin
		select	@Has_error HasErrors
	end
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors
	end


end
GO
/****** Object:  StoredProcedure [dbo].[Bedrooms_edit]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Bedrooms_edit]
@IdBedRoom int,
@NumberRoom int,
@State int,
@TypeRoom int,
@ReservetionState smallint,
@CostBase decimal(18,0)

as
begin
declare @Has_error int
declare @IdRoute int

set @Has_error = 0;

	IF exists(select 1 from dbo.Rooms where IdBedRoom = @IdBedRoom )
	begin
		update	dbo.Rooms
		set		NumberRoom = @NumberRoom,
				State = @State,
				TypeRoom = @TypeRoom,				
				ReservetionState = @ReservetionState,
				CostBase = @CostBase,
				TaxAmount = (@CostBase * 0.19),
				CostTotal = @CostBase + (@CostBase*0.19)
		where	IdBedRoom = @IdBedRoom 
		select	@Has_error HasErrors
	end
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors
	end
end
GO
/****** Object:  StoredProcedure [dbo].[BedroomsListXHotel]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[BedroomsListXHotel]
@IdHotel int

as
begin
declare @Has_error int
set @Has_error = 0
	
	IF EXISTS( SELECT * FROM dbo.Rooms where IdHotel = @IdHotel)
	begin
	SELECT	t_b.IdBedRoom,
			t_b.NumberRoom,
			case t_b.State
				when 1 then 'Activo'
			else
				'Inactivo'
			end State,
			t_bt.TypeBedrooms,			
			case t_b.ReservetionState
				when 1 then 'Disponible'
				when 2 then 'Reservado'
			else
				'Ocupado'
			end ReservetionState,
			t_b.CostBase,
			t_b.TaxAmount,
			t_b.CostTotal,
			t_b.Location,
			@Has_error HasErrors
	FROM	dbo.Rooms t_b
			inner join dbo.RoomsType t_bt on t_bt.IdType = t_b.TypeRoom
			inner join dbo.Hotels t_h on t_h.IdHotel = t_b.IdHotel
	where	t_b.IdHotel = @IdHotel
	end
	ELSE
	BEGIN
		SET @Has_error = 1
		SELECT @Has_error HasErrors -- El Hotel no esta registrado.
	END

end
GO
/****** Object:  StoredProcedure [dbo].[BedroomsLstAvailable]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[BedroomsLstAvailable]
@IdHotel int

as
begin

declare @Has_error int
set @Has_error = 0

	IF EXISTS( SELECT * FROM dbo.Rooms where IdHotel = @IdHotel and State = 1 and ReservetionState = 1 and TypeRoom <> 6)
	BEGIN
		SELECT	t_b.IdBedRoom,
				t_b.NumberRoom,
				t_bt.TypeBedrooms,
				
				case t_b.ReservetionState
					when 1 then 'Disponible'
					when 2 then 'Reservado'
				else
					'Ocupado'
				end ReservetionState,
				t_b.CostTotal,
				@Has_error HasErrors
		FROM	dbo.Rooms t_b
				inner join dbo.RoomsType t_bt on t_bt.IdType = t_b.TypeRoom
				inner join dbo.Hotels t_h on t_h.IdHotel = t_b.IdHotel
		where	t_b.IdHotel = @IdHotel
		and		t_b.ReservetionState = 1 -- Disponible
		and		t_b.TypeRoom <> 6 -- Creado
		and		t_b.State = 1 -- Activo
	END 
	ELSE
	BEGIN
		SET @Has_error = 1
		SELECT @Has_error HasErrors -- No hay habitaciones disponibles para el hotel
	END

end
GO
/****** Object:  StoredProcedure [dbo].[Booking_add]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Booking_add]
@IdPassenger int,
@IdHotel int,
@IdRoom int,
@DateInitial date,
@DateFinal date,
@PaymentForm smallint,
@Notas varchar(200)

as
begin

declare @Has_error int
declare @IdBookingAdd int
declare @vCostTotal decimal(18,0)

set @Has_error = 0
set @vCostTotal = 0
	
	select	@vCostTotal = CostTotal
	from	Rooms
	where	IdHotel = @IdHotel
	and		IdBedRoom = @IdRoom


	insert into dbo.Booking
	(
		IdPassenger,
		IdHotel,
		IdRoom,
		DateInitial,
		DateFinal,
		ReservetionState,
		CostTotal,
		PaymentForm,
		Notas
		
	) 	
	VALUES
	(
		@IdPassenger,
		@IdHotel,
		@IdRoom,
		@DateInitial,
		@DateFinal,
		2, -- Reservado
		@vCostTotal,
		@PaymentForm,
		@Notas
	)

	update	Rooms
	set		ReservetionState = 2 -- Reservado	
	where	IdBedRoom = @IdRoom
	and		IdHotel = @IdHotel

	SET @IdBookingAdd = (SELECT scope_identity());

	IF (@IdBookingAdd <> 0)
	begin
		select	t_bk.IdPassenger,
				t_h.Name,		
				t_r.NumberRoom,
				t_bk.DateInitial,
				t_bk.DateFinal,
				case t_bk.ReservetionState
					when 1 then 'Disponible'
					when 2 then 'Reservado'
				else
					'Ocupado'
				end ReservetionState,
				t_bk.CostTotal,
				case t_bk.PaymentForm
					when 1 then 'Efectivo'
					when 2 then 'Tarjeta credito'
					when 3 then 'Tarjeta debito'
					when 4 then 'Cheque'
				else
					'Transferencia'
				end PaymentForm,
				t_bk.Notas,
				@Has_error HasErrors
		from	dbo.Booking t_bk
				inner join dbo.Hotels t_h on t_h.IdHotel = t_bk.IdHotel
				inner join dbo.Rooms t_r on t_r.IdBedRoom = t_bk.IdRoom
		where	IdBooking = @IdBookingAdd
	end
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors
	end


end
GO
/****** Object:  StoredProcedure [dbo].[Hotel_add]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Hotel_add]

@Name varchar(50),
@Location varchar(50),
@RoomsNumber int,
@Phone numeric(18,0),
@State smallint

as
begin

declare @Has_error int
declare @IdHotel int
DECLARE @countRoom int
declare @NumberRoom int

set @Has_error = 0;
set @countRoom = 1;
set	@NumberRoom = 1;

	insert into dbo.Hotels
	(
		Name,
		Location,
		RoomsNumber,
		Phone,
		State
	) 	
	VALUES
	(
		@Name,
		@Location,
		@RoomsNumber,
		@Phone,
		@State
	)

	SET @IdHotel = (SELECT scope_identity());

	
	WHILE @countRoom <= @RoomsNumber
    BEGIN
        INSERT INTO dbo.Rooms (NumberRoom, State, TypeRoom, ReservetionState, CostBase, CostTotal, Location, TaxAmount, IdHotel)
        VALUES (@countRoom,@State,6,1,0,0,@Location,0,@IdHotel);

        SET @countRoom = @countRoom + 1;
    END;
	

	IF (@IdHotel <> 0)
	begin
		select	@Has_error HasErrors
	end
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors
	end


end
GO
/****** Object:  StoredProcedure [dbo].[Hotel_edit]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Hotel_edit]
@IdHotel	int,
@Name		varchar(50),
@Location	varchar(50),
@RoomsNumber	int,
@Phone			numeric(18,0),
@State			smallint

as
begin

declare @Has_error int

set @Has_error = 0

	IF exists(select 1 from dbo.Hotels where IdHotel = @IdHotel)
	BEGIN
		UPDATE	dbo.Hotels
		set		Name = @Name,
				Location = @Location,
				RoomsNumber = @RoomsNumber,
				phone = @Phone,
				State = @State
		where	IdHotel = @IdHotel

		select	@Has_error HasErrors
	END
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors
	end

end
GO
/****** Object:  StoredProcedure [dbo].[Hotel_edtit_state]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Hotel_edtit_state]
@IdHotel	int,
@state	smallint

as
begin

declare @Has_error int
set @Has_error = 0

	if exists(select 1 from dbo.Rooms where ReservetionState in(2,3)) and @state = 0  --reservadas o ocupadas
	begin
		set @Has_error = 2
		select	@Has_error HasErrors
		return;
	end

	IF exists(select 1 from dbo.Hotels where IdHotel = @IdHotel)
	BEGIN
		UPDATE	dbo.Hotels
		set		State = @state
		where	IdHotel = @IdHotel

		update	dbo.Rooms
		set		State = @state
		where	IdHotel = @IdHotel

		set @Has_error = 0
		select	@Has_error HasErrors

	END
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors
	end

end
GO
/****** Object:  StoredProcedure [dbo].[Hotel_list]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Hotel_list]

as
begin

declare @Has_error int
set @Has_error = 0

	if EXISTS( SELECT * FROM dbo.Hotels where State = 1)
	BEGIN
		SELECT	IdHotel,
				Name,
				@Has_error HasErrors
		FROM	dbo.Hotels t_u
				
	END 
	ELSE
	BEGIN
		SET @Has_error = 1
		SELECT @Has_error HasErrors
	END

end
GO
/****** Object:  StoredProcedure [dbo].[Hotel_List_Reserve]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[Hotel_List_Reserve]
@IdHotel int
as
begin

declare @Has_error int
declare @IdRoute int

set @Has_error = 0

	IF exists(select 1 from dbo.Rooms where IdHotel = @IdHotel)
	BEGIN
		select	t_b.IdBedRoom,
				t_h.Name NameHotel,
				t_b.NumberRoom,				
				t_bt.TypeBedrooms,
				case t_b.State
					when 1 then 'Activo'
				else
					'Inactivo'
				end State,
				case t_b.ReservetionState
					when 1 then 'Disponible'
					when 2 then 'Reservado'
				else
					'Ocupado'
				end ReservetionState,
				@Has_error HasErrors
		from	dbo.Rooms t_b
				inner join dbo.Hotels t_h on t_h.IdHotel = t_b.IdHotel
				inner join dbo.RoomsType t_bt on t_bt.IdType = t_b.TypeRoom
		where	t_b.IdHotel = @IdHotel
		and		t_b.ReservetionState = 2 -- Reservado
	END
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors -- 'No se encontraron reservas para este hotel'
	end

end
GO
/****** Object:  StoredProcedure [dbo].[Hotel_List_Reserve_detail]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Hotel_List_Reserve_detail]
@IdHotel int,
@IdBedRoom int

as
begin

declare @Has_error int


set @Has_error = 0

	IF exists(select 1 from dbo.Rooms where IdHotel = @IdHotel)
	BEGIN
		select	t_b.IdBedRoom,
				t_h.Name NameHotel,
				t_b.NumberRoom,				
				t_bt.TypeBedrooms,
				case t_b.State
					when 1 then 'Activo'
				else
					'Inactivo'
				end State,
				case t_b.ReservetionState
					when 1 then 'Disponible'
					when 2 then 'Reservado'
				else
					'Ocupado'
				end ReservetionState,
				CostBase,
				TaxAmount,
				CostTotal,
				@Has_error HasErrors
		from	dbo.Rooms t_b
				inner join dbo.Hotels t_h on t_h.IdHotel = t_b.IdHotel
				inner join dbo.RoomsType t_bt on t_bt.IdType = t_b.TypeRoom
		where	t_b.IdHotel = @IdHotel
		and		IdBedRoom = @IdBedRoom
		and		t_b.ReservetionState = 2 -- Reservado
	END
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors -- 'No se encontraron reservas para este hotel'
	end

end
GO
/****** Object:  StoredProcedure [dbo].[Passenger_add]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Passenger_add]
@Name varchar(100),
@Birthdate date,
@Genero smallint,
@DocumentType smallint,
@DocumentNumber bigint,
@Email varchar(150),
@phone bigint

as
begin

declare @Has_error int
declare @IdRoute int

set @Has_error = 0

	insert into dbo.Passenger
	(
		Name,
		Birthdate,
		Genero,
		DocumentType,
		DocumentNumber,
		Email,
		phone
	) 	
	VALUES
	(
		@Name,
		@Birthdate,
		@Genero,
		@DocumentType,
		@DocumentNumber,
		@Email,
		@phone
	)

	SET @IdRoute = (SELECT scope_identity());

	IF (@IdRoute <> 0)
	begin
		select	@Has_error HasErrors
	end
	else
	begin
		set		@Has_error = 1
		select	@Has_error HasErrors
	end


end
GO
/****** Object:  StoredProcedure [dbo].[ValidateUser]    Script Date: 15/02/2024 3:29:11 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ValidateUser]

@user varchar(50),
@pass varchar(50)

as
begin

declare @Has_error int
set @Has_error = 0

	if exists( SELECT * FROM dbo.Users where @user = UserDesc and @pass = Pass)
	BEGIN
		SELECT	t_u.IdUsuario,
				t_u.Name,
				t_u.State,
				t_rol.TypeRol,
				@Has_error HasErrors
		FROM	dbo.Users t_u
				inner join dbo.Rol t_rol on t_rol.IdRol = t_u.IdRol
		where	UserDesc = @user
		and		Pass = @pass
	END 
	ELSE
	BEGIN
		SET @Has_error = 1
		SELECT @Has_error HasErrors
	END

end
GO
