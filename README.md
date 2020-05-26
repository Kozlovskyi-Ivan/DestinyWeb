# DestinyWeb
## Web page for Destiny 2
A simple one-page site for Milestone weakly information reset in Destiny. This project consists of two parts. First is front-end on Angular and second is back-end on ASP.Net Core. It also has docker support. 

Front-end is divided into components to display their own Milestones. Each component makes a request to back-end to get data about milestone. 

Back-end has standard controllers for processing requests. It uses Destiny API to get data about Milestones then process a data to store in database. Application runs on ASP.net core 3 and uses EF core for manipulations with database.
[Example on heroku](https://destiny-reset.herokuapp.com/)
Warning, create a defaultconnection.txt with connection string for a database and key.txt for bungieAPI key.

![Example 1](/1.JPG)
![Example 2](/2.JPG)
---
## docker and friends 
