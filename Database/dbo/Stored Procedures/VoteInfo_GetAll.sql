﻿CREATE PROCEDURE VoteInfo_GetAll
AS

SELECT * FROM VoteInfo WHERE IsDeleted = 0