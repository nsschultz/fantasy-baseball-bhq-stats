## BHQ Stats Service
* Service used for retrieving the stats data from BHQ. 
* Pulls in data from multiple CSV files and exposes them through separate endpoints. 
* Players exposed from this service only contain the BHQ Player Key.

---
### Endpoints:
* `GET api/bhq-stats/batters` - Year to Date & Projected batting stats
* `GET api/bhq-stats/pitchers` - Year to Date & Projected pitching stats
* `POST api/bhq-stats/batters/upload` - Upload the latest Year to Date & Projected batting stats CSV File
* `POST api/bhq-stats/pitchers/upload` - Upload the latest Year to Date & Projected pitching stats CSV File

---
### Healthcheck:
* The service will fail a healthcheck if any of the CSV files are not accessible. 