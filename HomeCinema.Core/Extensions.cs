using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HomeCinema.Core
{
    public static class Extensions
    {
        /// <summary>
        /// Removes bounding double quotes from each end of a string, if present.
        /// </summary>
        /// <param name="quoted">String to remove quotes from.</param>
        /// <returns>Unquoted string.</returns>
        public static string Unquote(this string quoted)
        {
            if (String.IsNullOrWhiteSpace(quoted))
            {
                return quoted;
            }

            if (quoted.StartsWith("\"", StringComparison.Ordinal) && quoted.EndsWith("\"", StringComparison.Ordinal) && quoted.Length > 1)
            {
                return quoted.Substring(1, quoted.Length - 2);
            }

            return quoted;
        }


        /// <summary>
        /// Reads data from a stream until the end is reached. The
        /// data is returned as a byte array. An IOException is
        /// thrown if any of the underlying IO calls fail.
        /// </summary>
        /// <param name="stream">The stream to read data from</param>
        /// <param name="initialLength">The initial buffer length</param>
        /// http://www.yoda.arachsys.com/csharp/readbinary.html
        public static byte[] ReadFully(this Stream stream, long initialLength)
        {
            // If we've been passed an unhelpful initial length, just
            // use 32K.
            if (initialLength < 1)
            {
                initialLength = 32768;
            }

            byte[] buffer = new byte[initialLength];
            int read = 0;

            int chunk;
            while ((chunk = stream.Read(buffer, read, buffer.Length - read)) > 0)
            {
                read += chunk;

                // If we've reached the end of our buffer, check to see if there's
                // any more information
                if (read == buffer.Length)
                {
                    int nextByte = stream.ReadByte();

                    // End of stream? If so, we're done
                    if (nextByte == -1)
                    {
                        return buffer;
                    }

                    // Nope. Resize the buffer, put in the byte we've just
                    // read, and continue
                    byte[] newBuffer = new byte[buffer.Length * 2];
                    Array.Copy(buffer, newBuffer, buffer.Length);
                    newBuffer[read] = (byte)nextByte;
                    buffer = newBuffer;
                    read++;
                }
            }
            // Buffer is now too big. Shrink it.
            byte[] ret = new byte[read];
            Array.Copy(buffer, ret, read);
            return ret;
        }

        /// <summary>
        /// Limit string length
        /// </summary>
        /// <param name="str"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string LimitLengthTo(this string str, int length)
        {
            if (String.IsNullOrEmpty(str) == false)
            {
                return str.Substring(0, Math.Min(length, str.Length));
            }
            else
            {
                return str;
            }
        }
    }
}
