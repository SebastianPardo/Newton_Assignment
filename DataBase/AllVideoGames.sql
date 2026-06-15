CREATE VIEW VwAllVideoGames AS

SELECT
VGA.Id,
VGA.IsAvailable,
VGA.Title,
VGA.Quantity,
VGA.Price,
PLA.Code PlatformCode,
PLA.[Name] [Platform],
GEN.Code GenreCode,
GEN.[Name] [Genre]
FROM VideoGames VGA
JOIN Platforms PLA ON PLA.Id = VGA.PlatformId
JOIN Genres GEN ON GEN.Id = VGA.GenreId