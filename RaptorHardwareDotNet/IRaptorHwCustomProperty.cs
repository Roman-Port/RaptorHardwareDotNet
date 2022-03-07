using System;
using System.Collections.Generic;
using System.Text;

namespace RaptorHardwareDotNet
{
    public interface IRaptorHwCustomProperty
    {
        /// <summary>
        /// The display name of the property.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Can the property be written to?
        /// </summary>
        bool IsWritable { get; }

        /// <summary>
        /// The data type of the property.
        /// </summary>
        RaptorHwCustomPropertyType ValueType { get; }

        /// <summary>
        /// The value for this property exposed as a generic object
        /// </summary>
        object Value { get; set; }

        /// <summary>
        /// The value, as a string, for the property
        /// </summary>
        string ValueString { get; set; }

        /// <summary>
        /// The value, as an int, for the property
        /// </summary>
        int ValueInt { get; set; }

        /// <summary>
        /// The value, as a boolean, for the property
        /// </summary>
        bool ValueBool { get; set; }
    }
}
