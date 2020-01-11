using System;

namespace ProyectoFinalTecWeb.Exceptions
{
    public class NotFoundItemException : Exception
    {
        public NotFoundItemException(string message)
             : base(message)
        {

        }

    }
}
