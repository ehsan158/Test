using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Infrostructure.Enums
{
    public enum InstallmentStateEnum
    {
        /// <summary>
        /// ساخته شده
        /// </summary>
        [AttributeForDescription("Created", 1)]
        Created,

        /// <summary>
        /// پرداخت شده
        /// </summary>
        [AttributeForDescription("Paid", 2)]
        Paid
    }
}
