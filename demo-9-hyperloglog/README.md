# Demo 9: HyperLogLog

We use the included project to parse the text file, this is Data Science (TM) after all so the data needs cleaning.

Once it is parsed we insert the unique words into a HyperLogLog, in order to count the number of unique words.

Count at any stage with:

    pfcount shakespeare

Blank database:

    flushdb