﻿CREATE PROCEDURE UserInfo_GetAll
AS

SELECT * FROM UserInfo WHERE IsDeleted = 0