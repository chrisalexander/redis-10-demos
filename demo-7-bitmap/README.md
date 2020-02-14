# Demo 7. Bitmap

First, we load in the bitmap data. This is a good chance to show off Redis bulk insert.

You can generate the contents of bitmap-data with this C# code in the interactive window:

    using (var f = File.AppendText(@"path\to\bitmap-data")) {
        foreach (var i in Enumerable.Range(0, 1000000))
        {
            f.WriteLine($"setbit mybits {i} {(i % 10 == 0 ? 1 : 0)}");
        }
    }

Now load it into the server (assumes WSL):

    cat /mnt/c/path/to/redis-10-demos/demo-7-bitmap/bitmap-data | ./redis-cli --pipe

Now you can get the bits out of the bitmap:

    getbit mybits 5
    getbit mybits 10
    getbit mybits 999999
    getbit mybits 999990

Blank database:

    flushdb