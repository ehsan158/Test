using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Text;

namespace Infrostructure.Enums
{
    public enum OrderStateEnum
    {
        /// <summary>
        /// ساخته شده
        /// </summary>
        [AttributeForDescription("Created",1)]
        Created,

        /// <summary>
        /// خریداری شده
        /// </summary>
        [Description("Bought")]
        [AttributeForDescription("Bought", 2)]
        Bought,

        /// <summary>
        /// تسویه حساب شده
        /// </summary>
        [Description("CheckOut")]
        [AttributeForDescription("CheckOut", 3)]
        CheckOut,

        /// <summary>
        /// لغو شده
        /// </summary>
        [Description("Removed")]
        [AttributeForDescription("Removed", 4)]
        Removed
    }
}
