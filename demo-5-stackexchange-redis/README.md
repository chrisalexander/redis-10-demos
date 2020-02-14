# Demo 5. StackExchange.Redis

This is a very basic C# demo of StackExchange.Redis.

Before you start the solution, create a test key:

    set stackexchange demo-value

Then run the demo. It should output your value, and set a new key as a GUID.

    get stackexchange2

Blank database:

    flushdb