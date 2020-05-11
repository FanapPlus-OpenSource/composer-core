﻿using ComposerCore.Extensibility;

namespace ComposerCore.CompositionalQueries
{
    public class SimpleValueQuery : ICompositionalQuery
    {
        public SimpleValueQuery(object value)
        {
            Value = value;
        }

        #region Implementation of ICompositionalQuery

        public bool IsResolvable(IComposer composer)
        {
            return true;
        }

        public object Query(IComposer composer, IComposer scope = null)
        {
            return Value;
        }

        #endregion

        public override string ToString()
        {
            return $"SimpleValueQuery('{Value}')";
        }

        public object Value { get; }
    }
}