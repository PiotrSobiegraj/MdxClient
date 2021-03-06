﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.AnalysisServices.AdomdClient;
using System.Data.Common;

namespace MdxClient
{
    /// <summary>
    /// Represents a parameter to an MdxCommand
    /// </summary>
    public sealed class MdxParameter : DbParameter, ICloneable
    {
        /// <summary>
        /// Initializes a new instance of the MdxParameter class.
        /// </summary>
        public MdxParameter()
        {
            DbType = System.Data.DbType.AnsiString;
            Direction = ParameterDirection.Input;           
        }

        /// <summary>
        /// Initializes a new instance of the MdxParameter
        /// class that sets the name and a value for the parameter.
        /// </summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <param name="value">The value of the parameter.</param>
        public MdxParameter(string parameterName, object value)
            : this()
        {
            ParameterName = parameterName;
            Value = value;
        }

        internal MdxParameterCollection Parent { get; set; }

        /// <summary>
        /// Gets or sets the System.Data.DbType of the parameter.
        /// </summary>
        public override DbType DbType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating the direction of the parameter. 
        /// </summary>        
        public override ParameterDirection Direction { get; set; }

        /// <summary>
        /// Gets a value indicating whether the parameter accepts null values. 
        /// </summary>
        public override bool IsNullable { get; set; }

        /// <summary>
        /// Gets or sets the name of the parameter.
        /// </summary>
        public override string ParameterName { get; set; }

        /// <summary>
        /// Resets the type associated with this MdxParameter
        /// </summary>
        public override void ResetDbType()
        {
            DbType = System.Data.DbType.AnsiString;
        }

        /// <summary>
        /// Gets or sets the maximum size, in bytes, of the data within the column.
        /// </summary>
        public override int Size { get; set; }

        /// <summary>
        /// This property is reserved for future use.
        /// </summary>
        public override string SourceColumn { get; set; }

        /// <summary>
        /// This property is reserved for future use.
        /// </summary>
        public override bool SourceColumnNullMapping { get; set; }

        /// <summary>
        /// Gets or sets the DataRowVersion to use when loading MdxParameter.Value. Always returns DataRowVersion.Current.
        /// </summary>
        public override DataRowVersion SourceVersion 
        {
            get
            {
                return DataRowVersion.Current;
            }
            set
            {
                if (value != DataRowVersion.Current)
                    throw new ArgumentException("SourceVersion must be DataRowVersion.Current");
            }
        }

        /// <summary>
        /// Gets or sets the value of the parameter.
        /// </summary>
        public override object Value { get; set; }

        public object Clone()  // TODO: Is this needed?
        {
            return new MdxParameter(ParameterName, Value);
        }

        /// <summary>
        /// Gets a string that contains the ParameterName.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ParameterName;
        }
    }
}
