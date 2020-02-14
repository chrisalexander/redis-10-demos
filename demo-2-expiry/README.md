# Demo 2: Expiry

Create a string:

    set test-key test-value

Prove it's there:

    get test-key

Set the expiry:

    expire test-key 5

Still there?

    get test-key

\<wait 5 seconds>

Still there?

    get test-key

Blank database:

    flushdb