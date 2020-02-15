# Demo 8: Geo

I created the Geo file using data from [here](https://www.infoplease.com/world/world-geography/major-cities-latitude-longitude-and-corresponding-time-zones).

Load it into the server (assumes WSL):

    cat /mnt/c/path/to/redis-10-demos/demo-8-geo/geo-data | ./redis-cli --pipe

Configure a secret in the ASP.NET Core secrets file which is your Google Maps API key associated with a billing account.

Now when you run the ASP.Net core project, it will start a webpage that shows you a Google map you can click around to hit the API.

Blank database:

    flushdb