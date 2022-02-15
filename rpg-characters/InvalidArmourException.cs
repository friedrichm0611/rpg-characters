using System;
using System.Runtime.Serialization;

namespace rpg_characters
    {
    [Serializable]
    internal class InvalidArmourException : Exception
        {
        public InvalidArmourException()
            {
            Console.WriteLine( "You are not allowed to wear this amour." );
            Console.WriteLine( "The execution of the game will stop here!" );
            System.Environment.Exit( 1 );
            }

        public InvalidArmourException( string message ) : base( message )
            {
            Console.WriteLine( "You are not allowed to wear this amour." );
            Console.WriteLine( "The execution of the game will stop here!" );
            System.Environment.Exit( 1 );
            }

        public InvalidArmourException( string message, Exception innerException ) : base( message, innerException )
            {
            Console.WriteLine( "You are not allowed to wear this amour." );
            Console.WriteLine( "The execution of the game will stop here!" );
            System.Environment.Exit( 1 );
            }

        protected InvalidArmourException( SerializationInfo info, StreamingContext context ) : base( info, context )
            {
            Console.WriteLine( "You are not allowed to wear this amour." );
            Console.WriteLine( "The execution of the game will stop here!" );
            System.Environment.Exit( 1 );
            }
        }
    }