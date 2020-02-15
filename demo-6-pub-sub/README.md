# Demo 6: Pub/Sub

Make sure Redis is running with protected mode off if you are running on WSL:

    ./redis-server --protected-mode no

Build, then use the shortcuts to start one or two Publishers and several Consumers.

Anything you type in a producer will end up with all of the consumers.

Use character "x" in a producer to exit that producer, and also all the consumers.

Blank database:

    flushdb