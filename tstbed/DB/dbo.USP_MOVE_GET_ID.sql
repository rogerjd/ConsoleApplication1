﻿CREATE PROCEDURE [dbo].[USP_MOVIE_GET_ID]
	@id int = 0
AS
	SELECT *
	FROM Movie
	WHERE ID = @id

RETURN 0
