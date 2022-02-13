using System;
using System.Runtime.Serialization;

namespace rpg_characters
    {
    [Serializable]
    internal class InvalidLevelException : Exception
        {
        public InvalidLevelException()
            {
            Console.WriteLine("You are not allowed to wear this weapon. Your character level is too low!");
            System.Environment.Exit( 1 );
            }

        public InvalidLevelException( string message ) : base( message )
            {
            Console.WriteLine( "You are not allowed to wear this weapon. Your character level is too low!" );
            System.Environment.Exit( 1 );
            }

        public InvalidLevelException( string message, Exception innerException ) : base( message, innerException )
            {
            Console.WriteLine( "You are not allowed to wear this weapon. Your character level is too low!" );
            System.Environment.Exit( 1 );
            }

        protected InvalidLevelException( SerializationInfo info, StreamingContext context ) : base( info, context )
            {
            Console.WriteLine( "You are not allowed to wear this weapon. Your character level is too low!" );
            System.Environment.Exit( 1 );
            }
        }
    }