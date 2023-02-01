using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.ViewModels
{
    internal interface IAsyncInitialization
    {
        /// <summary>
        /// The result of the asynchronous initialization of this instance.
        /// see http://blog.stephencleary.com/2013/01/async-oop-2-constructors.html
        /// </summary>
        Task Initialization { get; }
    }
}
