# Demo 3: Lists and blocking operations

Push some things onto the right end of a list:

    rpush testlist a
    rpush testlist b c
    rpush testlist d e f

See what's in it:

    lrange testlist 0 -1

Add some on the left:

    lpush testlist 1
    lpush testlist 2
    lpush testlist 3

See what's in it:

    lrange testlist 0 -1

Let's pop something off the list from the right:

    rpop testlist

And off the left:

    lpop testlist

Now they're gone:

    lrange testlist 0 -1

In a new redis-cli, let's wait for something to arrive in a queue:

    brpop waitlist 30

In our original cli, let's do an atomic pop from the first list into the second:

    rpoplpush testlist waitlist

You can repeat those two a few times.

Blank database:

    flushdb