# Demo 1: Strings

Create a string:

    set test-key test-value

Read a key not set:

    get missing-key

Read a key that is set:

    get test-key

List keys (DO NOT USE IN PROD):

    keys *

Update a key:

    set test-key new-value

Read updated key:

    get test-key

Blank database:

    flushdb