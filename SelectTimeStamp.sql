Use FLuentApi

(select [Timestamp] from Match
where id = 1)

SELECT CAST( (select [Timestamp] from Match
where id = 1) AS INT)
GO