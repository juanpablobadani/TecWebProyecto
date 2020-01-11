using System;

namespace ProyectoFinalTecWeb.Exceptions
{
    public class BadRequestOperationException : Exception
    {

        public BadRequestOperationException(string message)
            : base(message)
        {

        }

    }
}
