using System;
using System.Runtime.Serialization;

namespace rpg_characters
    {
    [Serializable]
    internal class InvalidLevelException : Exception
        {
        public InvalidLevelException()
            {
            Console.WriteLine( "You are not allowed to wear this item. Your character level is too low!" );
            Console.WriteLine( "The execution of the game will stop here!" );
            System.Environment.Exit( 1 );
            }

        public InvalidLevelException( string message ) : base( message )
            {
            Console.WriteLine( "You are not allowed to wear this item. Your character level is too low!" );
            Console.WriteLine( "The execution of the game will stop here!" );
            System.Environment.Exit( 1 );
            }

        public InvalidLevelException( string message, Exception innerException ) : base( message, innerException )
            {
            Console.WriteLine( "You are not allowed to wear this item. Your character level is too low!" );
            Console.WriteLine( "The execution of the game will stop here!" );
            System.Environment.Exit( 1 );
            }

        protected InvalidLevelException( SerializationInfo info, StreamingContext context ) : base( info, context )
            {
            Console.WriteLine( "You are not allowed to wear this item. Your character level is too low!" );
            Console.WriteLine( "The execution of the game will stop here!" );
            System.Environment.Exit( 1 );
            }
        }
    }