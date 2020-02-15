# Demo 10: Streams

Please be aware this is an *extremely noddy* stream demo. For all the cool things you can do, please review the [Redis stream documentation](https://redis.io/topics/streams-intro).

The Producer project (shortcut in the root) creates a sin wave in the "sin" stream. Kick that off to start inserting data.

The ASP.net project has an API which makes a stream request, and renders it to the default webpage in an updating chart.

You can also read it yourself:

    xrange sin - +

Or get the length:

    xlen sin

Blank database:

    flushdb