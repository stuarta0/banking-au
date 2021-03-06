﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Banking.AU.Common.Validation
{
    [DebuggerDisplay("{Item}|{MemberName}|{Message}")]
    public class ValidationError<T> : IValidationError<T>
        where T : class
    {
        public T Item { get; set; }
        public string MemberName { get; set; }
        public string Message { get; set; }

        public ValidationError(string message)
            :this(null, message)
        {

        }
        public ValidationError(T item, string message)
            :this(item, null, message)
        {

        }
        public ValidationError(T item, string member, string message)
        {
            Item = item;
            MemberName = member;
            Message = message;
        }
    }
}
