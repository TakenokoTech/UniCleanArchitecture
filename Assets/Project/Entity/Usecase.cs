using System;
using Project.Scripts.Usecase;
using UnityEditor.PackageManager;

namespace Project.Entity
{
    public class Pending<TR> : Usecase<TR> where TR : struct
    {
    }

    public class Resolved<TR> : Usecase<TR> where TR : struct
    {
        public TR value { get; set; }

        public Resolved(TR value)
        {
            this.value = value;
        }
    }

    public class Rejected<TR> : Usecase<TR> where TR : struct
    {
        public Exception error { get; set; }

        public Rejected(Exception err)
        {
            error = err;
        }
    }

    public abstract class Usecase<TR> where TR : struct
    {
        public bool IsSuccess => GetOrNull() != null;
        public bool IsFailure => ExceptionOrNull() != null;

        public TR? GetOrNull()
        {
            try
            {
                var resolve = (Resolved<TR>) this;
                return resolve.value;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Exception ExceptionOrNull()
        {
            try
            {
                var reject = (Rejected<TR>) this;
                return reject.error;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private T? RunCatching<T>(Func<T> block) where T: struct
        {
            try { return block(); }
            catch (Exception e) { return null; }
        }
    }
}
