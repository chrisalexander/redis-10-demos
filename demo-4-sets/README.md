# Demo 4: Sets

Add some people to the set:

    sadd team tom
    sadd team dick
    sadd team sally
    sadd team divina

How many team members:

    scard team

Is dave in the team?

    sismember team dave

What about sally?

    sismember team sally

Make another team:

    sadd team2 tom dave sally marco

Who's in both teams?

    sinter team team2

What if Sally leaves?

    srem team sally
    srem team2 sally

What if Dave switches teams?

    smove team2 team dave

What's the end result:

    smembers team
    smembers team2

Let's make a set with everyone in it:

    sunionstore all team team2
    smembers all

Blank database:

    flushdb