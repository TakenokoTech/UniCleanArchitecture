﻿using System;

namespace Project.Scripts.Runtime.Entity
{
    public sealed class Pending<TR> : Usecase<TR> where TR : struct
    {
    }

    public sealed class Resolved<TR> : Usecase<TR> where TR : struct
    {
        public TR Value { get; private set; }

        public Resolved(TR value)
        {
            this.Value = value;
        }
    }

    public sealed class Rejected<TR> : Usecase<TR> where TR : struct
    {
        public System.Exception Error { get; private set; }

        public Rejected(System.Exception err)
        {
            Error = err;
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
                return resolve.Value;
            }
            catch (System.Exception e)
            {
                return null;
            }
        }

        public System.Exception ExceptionOrNull()
        {
            try
            {
                var reject = (Rejected<TR>) this;
                return reject.Error;
            }
            catch (System.Exception e)
            {
                return null;
            }
        }

        private T? RunCatching<T>(Func<T> block) where T: struct
        {
            try { return block(); }
            catch (System.Exception e) { return null; }
        }
    }
}