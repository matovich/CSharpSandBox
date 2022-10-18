using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxCore
{
    public class DisposeWithFinalizer : IDisposable
    {
        private bool disposed;
        private readonly IntPtr image;
        private readonly int status;

        public DisposeWithFinalizer(string filename)
        {
            status = GdipLoadImageFromFile(filename, out image);
            status = GdipImageForceValidation(new HandleRef(null, image));
        }

        /// <summary>
        /// The finalizer is because of the presence of DllImport
        /// </summary>
        ~DisposeWithFinalizer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// This supports being called from the Dispose method or the finalizer
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine($"{nameof(BitmapImage)}.{nameof(Dispose)}({disposing}) by {(disposing ? "user code" : "garbage collection.")}");

            if (disposed)
            {
                return;
            }

            //Note this is not in a disposing guard.
            IntGdipDisposeImage(new HandleRef(null, image));

            disposed = true;
        }

        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int GdipImageForceValidation(HandleRef image);

        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode)]
        public static extern int GdipLoadImageFromFile(string filename, out IntPtr image);

        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, EntryPoint = "GdipDisposeImage", CharSet = System.Runtime.InteropServices.CharSet.Unicode)] // 3 = Unicode
        [ResourceExposure(ResourceScope.None)]
        private static extern int IntGdipDisposeImage(HandleRef image);
    }

    public class BitmapImage : IDisposable
    {
        private bool disposed;
        private readonly IntPtr image;
        private readonly int status;

        public BitmapImage(string filename)
        {
            status = GdipLoadImageFromFile(filename, out image);
            status = GdipImageForceValidation(new HandleRef(null, image));
        }

        ~BitmapImage()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine($"{nameof(BitmapImage)}.{nameof(Dispose)}({disposing}) by {(disposing ? "user code" : "garbage collection.")}");

            if (disposed)
            {
                return;
            }

            IntGdipDisposeImage(new HandleRef(null, image));

            disposed = true;
        }

        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        [ResourceExposure(ResourceScope.None)]
        internal static extern int GdipImageForceValidation(HandleRef image);

        [DllImport("gdiplus.dll", CharSet = CharSet.Unicode)]
        public static extern int GdipLoadImageFromFile(string filename, out IntPtr image);

        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, EntryPoint = "GdipDisposeImage", CharSet = System.Runtime.InteropServices.CharSet.Unicode)] // 3 = Unicode
        [ResourceExposure(ResourceScope.None)]
        private static extern int IntGdipDisposeImage(HandleRef image);
    }

    /// <summary>
    /// Because this version is passed an image it uses Dispose on the image in the Dispose call and not a finalizer
    /// </summary>
    public class BitmapImage2 : IDisposable
    {
        private bool disposed;
        private readonly Bitmap image;

        public BitmapImage2(Bitmap image)
        {
            this.image = image;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Debug.WriteLine($"{nameof(BitmapImage)}.{nameof(Dispose)}({disposing}) by {(disposing ? "user code" : "garbage collection.")}");

            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                image.Dispose();
            }

            disposed = true;
        }
    }
}
