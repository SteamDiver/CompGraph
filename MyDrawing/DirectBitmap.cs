using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MyDrawing
{
        public class DirectBitmap : IDisposable
        {
            public Bitmap Bitmap { get; private set; }
            public int[] Bits { get; private set; }
            public bool Disposed { get; private set; }
            public int Height { get; private set; }
            public int Width { get; private set; }

            protected GCHandle BitsHandle { get; private set; }

            public DirectBitmap(int width, int height)
            {
                Width = width;
                Height = height;
                Bits = new int[width * height];
                BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
                Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
            }

            public DirectBitmap(Bitmap bmp)
            {
                Width = bmp.Width;
                Height = bmp.Height;
                Bits = new int[bmp.Width * bmp.Height];
                BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
                Bitmap = new Bitmap(bmp.Width, bmp.Height, bmp.Width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());

                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, bmp.PixelFormat);
                IntPtr ptr = bmpData.Scan0;
                Marshal.Copy(ptr, Bits, 0, bmp.Width * bmp.Height);
                bmp.UnlockBits(bmpData);
            }

            public void SetPixel(int x, int y, Color colour)
            {
                int index = x + (y * Width);
                int col = colour.ToArgb();

                Bits[index] = col;
            }

            public Color GetPixel(int x, int y)
            {
                int index = x + (y * Width);
                if (index < Bits.Length && index > 0)
                {
                    int col = Bits[index];
                    return Color.FromArgb(col);
                }

                return Color.Red;
            }

            public void Dispose()
            {
                if (Disposed) return;
                Disposed = true;
                Bitmap.Dispose();
                BitsHandle.Free();
            }
        }
    }
