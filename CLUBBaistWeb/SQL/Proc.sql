USE [ClubBAIST]
GO
/****** Object:  StoredProcedure [dbo].[AddEntry]    Script Date: 29-02-2020 20:46:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter PROCEDURE [dbo].[AddScore](@MemberNumber int=null, @Tee NVARCHAR(5) = NULL,@Hole1 int=null,@Hole2 int=null,@Hole3 int=null,@Hole4 int=null,@Hole5 int=null,@Hole6 int=null,@Hole7 int=null,@Hole8 int=null,@Hole9 int=null,@Hole10 int=null,@Hole11 int=null,@Hole12 int=null,@Hole13 int=null,@Hole14 int=null,@Hole15 int=null,@Hole16 int=null,@Hole17 int=null,@Hole18 int=null,@Total int=null,@HandicapDifferential float=null)
AS
DECLARE @ReturnCode INT = 1
IF @MemberNumber IS NULL
		RAISERROR('AddScore error - Required parameter @MemberNumber',16,1)
ELSE IF @Tee IS NULL
			RAISERROR('AddScore error - Required parameter @Tee',16,1)
				ELSE IF @Hole1 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole1',16,1)
				ELSE IF @Hole2 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole2',16,1)
				ELSE IF @Hole3 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole3',16,1)
				ELSE IF @Hole4 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole4',16,1)
				ELSE IF @Hole5 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole5',16,1)
				ELSE IF @Hole6 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole6',16,1)
				ELSE IF @Hole7 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole7',16,1)
				ELSE IF @Hole8 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole8',16,1)
				ELSE IF @Hole9 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole9',16,1)
				ELSE IF @Hole10 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole10',16,1)
				ELSE IF @Hole11 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole11',16,1)
				ELSE IF @Hole12 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole12',16,1)
				ELSE IF @Hole13 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole13',16,1)
				ELSE IF @Hole14 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole14',16,1)
				ELSE IF @Hole15 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole15',16,1)
				ELSE IF @Hole16 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole16',16,1)
				ELSE IF @Hole17 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole17',16,1)
				ELSE IF @Hole17 IS NULL
				RAISERROR('AddScore error - Required parameter @Hole18',16,1)
				ELSE IF @Total IS NULL
				RAISERROR('AddScore error - Required parameter @Total',16,1)
				ELSE IF @HandicapDifferential IS NULL
				RAISERROR('AddScore error - Required parameter @HandicapDifferential',16,1)

ELSE
	BEGIN
		INSERT INTO Score VALUES
		(@MemberNumber,@Tee,GETDATE(),@Hole1,@Hole2,@Hole3,@Hole4,@Hole5,@Hole6,@Hole7,@Hole8,@Hole9,@Hole10,@Hole11,@Hole12,@Hole13,@Hole14,@Hole15,@Hole16,@Hole17,@Hole18,@Total,@HandicapDifferential)
		
	END
RETURN @ReturnCode
